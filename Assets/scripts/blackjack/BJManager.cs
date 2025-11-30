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
    public int playerTotal;
    public bool CanTakeCard = true;
    [Header("               ----- Dealer Settings-----")]
    public List<Transform> DealerSpawnCardList; 
    public List<Card> DealerCardList;
    public int dealerSpawnNumber = 0;
    public int dealerTotal;
    public Sprite BgSprite;
    public GameObject CardBG;
    private void Start()
    {
        StartGame();
    }
    
    public void StartGame()
    {
        RestartGame();
        DealerHit();
        DealerHit();
        // player card Settings
        TakeCard();
        TakeCard();
    }
    public void TakeCard()
    {
        if (!CanTakeCard)
        {
            return;
        }
        Card tempCard = cardStack.Pop();
        GameObject tempGO = Instantiate(new GameObject(), PlayerSpawnCardList[playerSpawnNumber].position, Quaternion.identity);
        tempGO.AddComponent<SpriteRenderer>();
        tempGO.GetComponent<SpriteRenderer>().sprite = tempCard.sprite;
        tempGO.name = tempCard.name;
        PlayeCardList.Add(tempCard);
        if (playerSpawnNumber < PlayerSpawnCardList.Count - 1)
        {
            playerSpawnNumber++;
        }
        Total();
    }
    public void DealerHit()
    {
        Card tempCard = cardStack.Pop(); 
        GameObject tempGO = Instantiate(new GameObject(), DealerSpawnCardList[dealerSpawnNumber].position, Quaternion.identity);
        // dealer cards 
        tempGO.AddComponent<SpriteRenderer>();
        tempGO.GetComponent<SpriteRenderer>().sprite = tempCard.sprite;
        tempGO.name = tempCard.name;
        DealerCardList.Add(tempCard);
        if (dealerSpawnNumber < DealerSpawnCardList.Count - 1)
        {
            dealerSpawnNumber++;
        }
        Total();
    }
    public void  Total()
    {
        playerTotal = 0; 
        foreach (Card tempCard in PlayeCardList)
        {
            playerTotal += tempCard.Value;
        }
        dealerTotal = 0;
        foreach (Card tempCard in DealerCardList)
        {
            dealerTotal += tempCard.Value;
        }
        CheckWins();
    }

    public void CheckWins()
    {
        if (playerTotal > 21)
        {
            DealerWins();
        }
        if (playerTotal == 21)
        {
            Playerwins();
        }
        if (dealerTotal == 21)
        {
            DealerWins();
        }
        if (playerTotal > dealerTotal && playerTotal < 21)
        {
            Playerwins();
        }
        if (dealerTotal > playerTotal && dealerTotal < 21)
        {
            DealerWins();
        }
    }

    public void Playerwins()
    {
        
    }
    
    public void DealerWins()
    {
        
    }

    public void DealerGame()
    {
        Total();
    }
    
    public void hitButton()
    {
        TakeCard();
        DealerGame();
    }

    public void stayButton()
    {
        CanTakeCard = false;
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