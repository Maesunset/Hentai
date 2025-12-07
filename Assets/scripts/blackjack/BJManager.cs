using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BJManager : MonoBehaviour
{
    [Header("               ----- General Setttings -----")]
    public List<Card> cards;
    public Stack<Card> cardStack;
    public GameObject ResetButton;
    private List<GameObject> cardList = new List<GameObject>();
    public TextMeshProUGUI statusText;
    public GameObject statusTextGM;
    public GirlLove ActuaGirlLove;
    public string[] winMessage;
    public string[] loseMessage;
    [Header("               ----- Player Settings-----")]
    public List<Transform> PlayerSpawnCardList; 
    public List<Card> PlayeCardList;
    public int playerSpawnNumber = 0;
    public int playerTotal;
    public bool CanTakeCard = true;
    [Header("               ----- Dealer Settings-----")]
    public List<Transform> DealerSpawnCardList; 
    public List<Card> DealerCardList;
    public bool canDealerPlay = true;
    public int dealerSpawnNumber = 0;
    public int dealerTotal;
    public Sprite BgSprite;
    public GameObject CardBG;
    private void Start()
    {
        RestartGame();
    }
    
    private void StartGame()
    {
        ResetButton.SetActive(false);
        DealerHit();
        DealerHit();
        // player card Settings
        TakeCard();
        TakeCard();
        Total();
        if (dealerTotal == 21)
        {
            DealerWins();
        }
        if (playerTotal == 21)
        {
            Playerwins();
        }
    }
    private void TakeCard()
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
        cardList.Add(tempGO);
        if (playerSpawnNumber < PlayerSpawnCardList.Count - 1)
        {
            playerSpawnNumber++;
        }
        Total();
        if (playerTotal > 21)
        {
            DealerWins();
        }
        if (playerTotal == 21)
        {
            Playerwins();
        }
    }
    private void DealerHit()
    {
        Card tempCard = cardStack.Pop(); 
        GameObject tempGO = Instantiate(new GameObject(), DealerSpawnCardList[dealerSpawnNumber].position, Quaternion.identity);
        tempGO.AddComponent<SpriteRenderer>();
        tempGO.GetComponent<SpriteRenderer>().sprite = tempCard.sprite;
        tempGO.name = tempCard.name;
        DealerCardList.Add(tempCard);
        cardList.Add(tempGO);
        if (dealerSpawnNumber < DealerSpawnCardList.Count - 1)
        {
            dealerSpawnNumber++;
        }
    }
    private void  Total()
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
    }

    private void Playerwins()
    {
        ActuaGirlLove.AddHappiness();
        ResetButton.SetActive(true);
        statusTextGM.SetActive(true);
        statusText.text = "you wins";
        canDealerPlay = false;
    }
    
    private void DealerWins()
    {
        ActuaGirlLove.SubtractHappiness();
        ResetButton.SetActive(true);
        statusTextGM.SetActive(true);
        statusText.text = "Dealer wins";
        canDealerPlay = false;
    }

    private void DealerGame()
    {
        while (canDealerPlay)
        {
            Total();
            if ((dealerTotal >= playerTotal && dealerTotal < 21) || dealerTotal == 21)
            {
                DealerWins();
                break;
            }
            if (dealerTotal > 21)
            {
                Playerwins();
                break;
            }
            DealerHit();
        }
    }
    
    public void hitButton()
    {
        TakeCard();
    }

    public void StayButton()
    {
        CanTakeCard = false;
        DealerGame();
    }

    public void RestartGame()
    {
        foreach (GameObject tempCard in cardList)
        {
            Destroy(tempCard);
        }
        CanTakeCard = true;
        canDealerPlay = true;
        statusTextGM.SetActive(false);
        cardList = new List<GameObject>();
        DealerCardList = new List<Card>();
        PlayeCardList = new List<Card>();
        playerSpawnNumber = 0;
        dealerSpawnNumber = 0;
        ShuffleStack();
        ResetButton.SetActive(false);
        StartGame();
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