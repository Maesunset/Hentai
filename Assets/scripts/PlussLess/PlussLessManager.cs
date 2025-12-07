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

    private void Start()
    { 
        int randomPrevieCard = Random.Range(0, cardList.Count);
        actualCard = cardList[randomPrevieCard];
        Debug.Log(actualCard.name);
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

    }

    IEnumerator PlussEnumerator()
    {
        yield return new WaitForSeconds(revealTime);
        if (actualCard.Value > previeCard.Value)
        {
            Debug.Log("win");
        }
        else
        {
            Debug.Log("Lose");
        }
    }

    public void Less()
    {
        StartCoroutine(Reroll());
        StartCoroutine(LessEnumerator());

    }

    IEnumerator LessEnumerator()
    {
        yield return new WaitForSeconds(revealTime);
        if (actualCard.Value < previeCard.Value)
        {
            Debug.Log("win");
        }
        else
        {
            Debug.Log("Lose");
        }
    }
}
