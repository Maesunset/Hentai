using System.Collections.Generic;
using UnityEngine;

public class PlussLessManager : MonoBehaviour
{
    [Header("Basics")]
    public List<Card> cardList;
    public GameObject cardHolder;
    public Card previeCard;
    public Card actualCard;

    private void Start()
    { 
        int randomPrevieCard = Random.Range(0, cardList.Count);
        actualCard = cardList[randomPrevieCard];
        Debug.Log(actualCard.name);
        cardHolder.GetComponent<SpriteRenderer>().sprite = actualCard.sprite;
        
    }

    private void Reroll()
    {
           previeCard = actualCard;
           int randomPrevieCard = Random.Range(0, cardList.Count);
           actualCard = cardList[randomPrevieCard];
           cardHolder.GetComponent<SpriteRenderer>().sprite = actualCard.sprite;
    }

    public void Plus()
    {
        Reroll();
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
        Reroll();
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
