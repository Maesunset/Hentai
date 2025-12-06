using System.Collections.Generic;
using UnityEngine;

public class PlussLessManager : MonoBehaviour
{
    [Header("Basics")]
    public List<Card> cardList;
    public Card previeCard;
    public Card actualCard;

    private void Start()
    { 
        int randomPrevieCard = Random.Range(0, cardList.Count);
        previeCard = cardList[randomPrevieCard];
        Debug.Log(previeCard.name);
        
    }

    public void Plus()
    {
        
    }

    public void Less()
    {
        
    }
}
