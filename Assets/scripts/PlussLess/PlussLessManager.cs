using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlussLessManager : MonoBehaviour
{
    [Header("Basics")]
    public List<Card> cardList;
    public GameObject cardHolder;
    public Sprite cardHolderSprite;
    public Card previeCard;
    public Card actualCard;
    public float revealTime;
    public GirlLove girlLove;
    public int treshold;

    private void Start()
    { 
        int randomPrevieCard = Random.Range(0, cardList.Count);
        actualCard = cardList[randomPrevieCard];
        cardHolder.GetComponent<SpriteRenderer>().sprite = actualCard.sprite;
    }

    IEnumerator Reroll()
    {
        cardHolder.GetComponent<SpriteRenderer>().sprite = cardHolderSprite;
        yield return new WaitForSeconds(revealTime);
        previeCard = actualCard;
        int randomPrevieCard = Random.Range(0, cardList.Count);
        actualCard = cardList[randomPrevieCard];
        cardHolder.GetComponent<SpriteRenderer>().sprite = actualCard.sprite;
        yield return null;
    }

    public void Plus()
    {
        StartCoroutine(Reroll());
        StartCoroutine(PlussEnumerator());
        Debug.Log("plus");
    }

    IEnumerator PlussEnumerator()
    {
        yield return new WaitForSeconds(revealTime + 0.2f);
        if (actualCard.Value > previeCard.Value)
        {
            Debug.Log("win");
            if ((actualCard.Value - previeCard.Value) > treshold)
            {
                girlLove.AddHappiness();
            }
        }
        else
        {
            Debug.Log("Lose");
            girlLove.SubtractHappiness();
        }
    }

    public void Less()
    {
        StartCoroutine(Reroll());
        StartCoroutine(LessEnumerator());
        Debug.Log("less");

    }

    IEnumerator LessEnumerator()
    {
        yield return new WaitForSeconds(revealTime + 0.2f);
        if (actualCard.Value < previeCard.Value)
        {
            Debug.Log("win");
            if ((previeCard.Value - actualCard.Value) > treshold)
            {
                girlLove.AddHappiness();
            }
        }
        else
        {
            Debug.Log("Lose");
            girlLove.SubtractHappiness();
        }
    }
}