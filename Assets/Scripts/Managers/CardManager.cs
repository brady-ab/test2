using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardManager : MonoBehaviour
{


    public static CardManager instance;
    public List<Card> cards = new List<Card>();
    public Transform player1Hand, player2Hand;
    public Transform player1DeckPanel, player2DeckPanel;
    public ThisCard thisCardPrefab;
    public List<ThisCard> player1Cards = new List<ThisCard>(),
        player2Cards = new List<ThisCard>(), player1HandCards = new List<ThisCard>(), player2HandCards = new List<ThisCard>();

    public List<int> player1Deck = new List<int>();
    public List<int> player2Deck = new List<int>();

    public List<ThisCard> player1ThisDeck = new List<ThisCard>();
    public List<ThisCard> player2ThisDeck = new List<ThisCard>();

    public RectTransform cardSize = new RectTransform();
    int deckCount1;

    private void Awake()
    {
        instance = this;

    }

    int LoopDeckFill()
    {
        for (int i = 1; i < 11; i++)
        {

            player1Deck.Add(i);
        }
        return player1Deck.Count;

    }
    // Start is called before the first frame update
    void Start()
    {
        deckCount1 = LoopDeckFill();
        FillDecks();
    }


   
    public void ProcessStartTurn(int ID)
    {
        bool drawCard = false;
        if (ID == 0)
        {
            drawCard = player1HandCards.Count < 6;
        }
        else
        {
            drawCard = player2HandCards.Count < 6;

        }

        if (drawCard && ID == 0)
        {
            if (player1ThisDeck.Count > 0)
            {
                int randomCard = UnityEngine.Random.Range(0, player1ThisDeck.Count);
                ThisCard drawnCard = player1ThisDeck[randomCard];
                // DO I NEED THIS? ThisCard newCard = Instantiate(thisCardPrefab, player1Hand);
                drawnCard.transform.SetParent(player1Hand);
                drawnCard.transform.localRotation = Quaternion.Euler(0, 0, 0);
                drawnCard.transform.localScale = new Vector3(1f, 1f, 1f);

                //drawnCard.GetComponent<RectTransform>() = 
                  
                drawnCard.originalParent = player1Hand;
                drawnCard.transform.localPosition = Vector3.zero;
                drawnCard.cardBack.gameObject.SetActive(false);
                //drawnCard.Initialize(this.cards[randomCard], ID);

                player1HandCards.Add(drawnCard);
                player1ThisDeck.Remove(drawnCard);
            }
        }
        
        else if(drawCard && ID == 1)
        {
            int randomCard = UnityEngine.Random.Range(0, player2Deck.Count);
            ThisCard newCard = Instantiate(thisCardPrefab, player2Hand);
            newCard.transform.localPosition = Vector3.zero;
            newCard.Initialize(this.cards[randomCard], ID);
            player2HandCards.Add(newCard);


        }
    }

    private void FillDecks()
    {
        foreach (int cardID in player1Deck)
        {
            ThisCard newCard = Instantiate(thisCardPrefab, player1DeckPanel);
            newCard.transform.localPosition = Vector3.zero;
            newCard.Initialize(CardDatabase.cardList[cardID], 0);
            newCard.cardBack.gameObject.SetActive(true);
            newCard.transform.localRotation = Quaternion.Euler(0, 0, 90);
            newCard.transform.localScale = new Vector3(0.61f, 0.61f, 0.61f);
            player1ThisDeck.Add(newCard);
            //Debug.Log(player1ThisDeck.Count);

        }

        foreach (int cardID in player2Deck)
        {
            ThisCard newCard = Instantiate(thisCardPrefab, player2DeckPanel);
            newCard.transform.localPosition = Vector3.zero;
            newCard.Initialize(CardDatabase.cardList[cardID], 1);

        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GenerateCards()
    {
        foreach(Card card in cards)
        {
            ThisCard newCard = Instantiate(thisCardPrefab, player1Hand);
            newCard.transform.localPosition = Vector3.zero;
            newCard.Initialize(card, 0);
            player1HandCards.Add(newCard);
        }

        foreach (Card card in cards)
        {
            ThisCard newCard = Instantiate(thisCardPrefab, player2Hand);
            newCard.transform.localPosition = Vector3.zero;
            newCard.Initialize(card, 1);
            player2HandCards.Add(newCard);

        }
    }

    public void PlayCard(ThisCard card, int ID)
    {
        if (ID == 0)
        {
            player1Cards.Add(card);
            player1HandCards.Remove(card);
        }
        if(ID == 1)
        {
            player2Cards.Add(card);
            player2HandCards.Remove(card);

        }
    }


    public static void Attack(GameObject attackerObject, GameObject defenderObject)
    {

        defenderObject.GetComponentInChildren<ThisCard>().cardHealth = defenderObject.GetComponentInChildren<ThisCard>().cardHealth - attackerObject.GetComponentInChildren<ThisCard>().attackDamage;
        attackerObject.GetComponentInChildren<ThisCard>().cardHealth = attackerObject.GetComponentInChildren<ThisCard>().cardHealth - defenderObject.GetComponentInChildren<ThisCard>().attackDamage;

        attackerObject.GetComponentInChildren<ThisCard>().canAttack = false;

        ThisCard.AdjustValues(defenderObject.GetComponentInChildren<ThisCard>());
        ThisCard.AdjustValues(attackerObject.GetComponentInChildren<ThisCard>());

        if (attackerObject.GetComponentInChildren<ThisCard>().cardHealth <= 0)
        {
            Destroy(attackerObject);
        }

        if (defenderObject.GetComponentInChildren<ThisCard>().cardHealth <= 0)
        {
            Destroy(defenderObject);
        }



    }
}
