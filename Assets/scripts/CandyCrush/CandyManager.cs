using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class CandyManager : MonoBehaviour
{
    public List<Sprite> candySprites;
    public GameObject candyPrefab;
    private List<List<GameObject>> candysList;

    private void Start()
    {
        
    }

    public void Spawn()
    {
        int randomSprite = Random.Range(0, candySprites.Count);
        GameObject Temp = candyPrefab;
        Temp.GetComponent<SpriteRenderer>().sprite = candySprites[randomSprite];
        Temp.GetComponent<CandyType>().icon = GetEnum(randomSprite);
        Debug.Log(randomSprite);
        Debug.Log(Temp.GetComponent<CandyType>().icon);
    }
    public void Reroll()
    {
        Spawn();
    }

    public IconType GetEnum(int enumIndex)
    {
        Array enumValues = Enum.GetValues(typeof(IconType));
        return (IconType)enumValues.GetValue(enumIndex);
    }
}
