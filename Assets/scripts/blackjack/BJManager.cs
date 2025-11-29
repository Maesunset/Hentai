using System;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BJManager : MonoBehaviour
{
    public List<Card> cards;
    public Stack<Card> cardStack;

    private void Start()
    {
        RestartGame();
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
            List<Card> temp = cards;
            System.Random rng = new System.Random();
            for (int i = temp.Count - 1; i > 0; i--)
            {
                int j = rng.Next(i + 1);
                Card swap = temp[i];
                temp[i] = temp[j];
                temp[j] = swap;
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