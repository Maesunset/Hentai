using System.Collections.Generic;
using UnityEngine;

public class BJManager : MonoBehaviour
{
    [Header("               ----- General Setttings -----")]
    public List<Card> cards;
    public Stack<Card> cardStack;
    [Header("               ----- Player Settings-----")]
    public List<Transform> PlayerSpawnCardList; 
    public List<Card> PlayeCardList;
    public int playerSpawnNumber = 0;
    [Header("               ----- Dealer Settings-----")]
    public List<Transform> DealerSpawnCardList; 
    public List<Transform> DealerCardList;
    private void Start()
    {
        StartGame();
    }
    
    public void StartGame()
    {
        RestartGame();
        TakeCard();
    }
    
    public void TakeCard()
    {
        Card tempCard = cardStack.Pop();
        GameObject tempGO = new GameObject();
        tempGO.AddComponent<SpriteRenderer>();
        tempGO.GetComponent<SpriteRenderer>().sprite = tempCard.sprite;
        tempGO.transform.position = PlayerSpawnCardList[playerSpawnNumber].position;
        if (playerSpawnNumber < PlayerSpawnCardList.Count - 1)
        {
            playerSpawnNumber++;
        }
    }

    public void hitButton()
    {
        TakeCard();
    }

    public void staryButton()
    {
        
    }
    private void RestartGame()
    {
        ShuffleStack();   
    }
    
    private void ShuffleStack()
    {
        if (cards.Count > 0)
        {
            cardStack = new Stack<Card>();
            System.Random rng = new System.Random();
            for (int i = cards.Count - 1; i > 0; i--)
            {
                int j = rng.Next(i + 1);
                Card tempSwap = cards[i];
                cards[i] = cards[j];
                cards[j] = tempSwap;
            }
            foreach (Card card in cards)
            {
                cardStack.Push(card);
            }
        }
        else
        {
            Debug.Log("no cards");
        }
    }
}

public enum CardType
{
    Picas,
    Corazones,
    Treboles,
    Diamantes,
}