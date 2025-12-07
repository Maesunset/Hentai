using UnityEngine.UI;
using UnityEngine;

public class GirlLove : MonoBehaviour
{

    public int minLoveCount = 1;
    public int maxLoveCount = 10;
    public int loveCount;
    public GameObject girlGameObject;
    public Sprite tier1;
    public Sprite tier2;
    public Sprite tier3;
    public Slider LoveSlider;


    private void Start()
    {
        loveCount = minLoveCount;
        UpdateSprite();
    }

    public void AddHappiness()
    {
        loveCount++;
        if (loveCount > maxLoveCount)
        {
            loveCount = maxLoveCount;
        }
        UpdateSprite();
    }    
    public void SubtractHappiness()
    {
        loveCount--;
        if (loveCount < minLoveCount)
        {
            loveCount = minLoveCount;
        }
        UpdateSprite();
    }

    public void UpdateSprite()
    {
        LoveSlider.value = loveCount;
        if (loveCount >= 8)
        {
            girlGameObject.GetComponent<SpriteRenderer>().sprite = tier3;
        }
        else if (loveCount >= 5)
        {
            girlGameObject.GetComponent<SpriteRenderer>().sprite = tier2;
        }
        else
        {
            girlGameObject.GetComponent<SpriteRenderer>().sprite = tier1;
        }
    }
}
