using System;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BJManager : MonoBehaviour
{
    public List<Card> cards;
    public Stack<Card> cardStack;
    public List<Transform> PlayerSpawnCardList; 
    public List<Transform> DealerSpawnCardList; 
    
    private void Start()
    {
        RestartGame();
    }

    public void StartGame()
    {
        
    }

    public void TakeCard()
    {
        
    }
    private void RestartGame()
    {
        shuffleStack();   
    }

    private void shuffleStack()
    {
        if (cards.Count > 0)
        {
            cardStack = new Stack<Card>();
            Debug.Log("shuffle cards");
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

public enum CardValue
{
    
}
