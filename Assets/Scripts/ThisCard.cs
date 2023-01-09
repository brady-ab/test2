using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;
using System;

public class ThisCard : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerDownHandler, IPointerUpHandler, IDragHandler, IBeginDragHandler, IEndDragHandler
{
    public Card card;
    public List<Card> thisCard = new List<Card>();
    
    public GameObject namePlate;
    public GameObject traitsPlate;
    public GameObject weaponPlate;
    public GameObject cardBackground;
    public Transform originalParent;
    
    internal int ownerID;
    public int id;

    public string cardName;
    public int sealCost;
    public int attackDamage;
    public int cardHealth;
    public string traits;

    public TMP_Text nameText;
    public TMP_Text costText;
    public TMP_Text attackDamageText;
    public TMP_Text healthText;
    public TMP_Text traitsText;

    public bool canAttack;
    public bool isPlayed;
    public int playID;
    public GameObject defenderObject;

    public GameObject cardBack;

    public Image image;

    Card defender = new Card();
    Card attacker = new Card();

    private void Awake()
    {
        image = GetComponent<Image>();

    }
    // Start is called before the first frame update
    void Start()
    {
        //thisCard[0] = CardDatabase.cardList[thisId];
        
    }

    public void Initialize(Card card, int ownerID)
    {

        id = card.id;
        cardName = card.cardName;
        sealCost = card.sealCost;
        attackDamage = card.attackDamage;
        cardHealth = card.cardHealth;
        traits = card.traits;

        //cardBack = card.cardBack;


        this.card = new Card(card)
        {
            ownerID = ownerID
        };

        //image.sprite = image;
        nameText.text = cardName;
        costText.text = sealCost.ToString();
        attackDamageText.text = attackDamage.ToString();
        healthText.text = cardHealth.ToString();
        traitsText.text = traits;

        originalParent = transform.parent;

        if (card.cardHealth == 0) healthText.text = "";

        //Code from first tutorial

        //this.card = card;
        //id = thisCard[0].id;
        //cardName = thisCard[0].cardName;
        //sealCost = thisCard[0].sealCost;
        //attackDamage = thisCard[0].attackDamage;
        //health = thisCard[0].cardHealth;
        //traits = thisCard[0].traits;

        //nameText.text = "" + cardName;
        //costText.text = "" + sealCost;
        //attackDamageText.text = "" + attackDamage;
        //healthText.text = "" + health;
        //traitsText.text = "" + traits;

        //staticCardBack = cardBack;


    }

    public static void AdjustValues(ThisCard card)
    {
        
        card.healthText.text = card.cardHealth.ToString();
    }



    // Update is called once per frame
    void Update()
    {

        //check for victory
    }


    public void OnPointerDown(PointerEventData eventData)
    {
        if (isPlayed) //if played
        {
            namePlate.transform.SetAsFirstSibling();
            namePlate.gameObject.SetActive(true);
            traitsPlate.transform.SetAsFirstSibling();
            traitsPlate.gameObject.SetActive(true);
            cardBackground.transform.SetAsFirstSibling();
            cardBackground.gameObject.SetActive(true);
            weaponPlate.transform.SetAsFirstSibling();
            weaponPlate.gameObject.SetActive(true);


        }
        else
        {
            if (TurnManager.instance.currentPlayerTurn == card.ownerID) // if yours and not played
            {

                transform.SetParent(transform.root);
                image.raycastTarget = false;
            }

            else // if not yours and not played, do nothing
            {

            }
        }
    }



    public void OnPointerUp(PointerEventData eventData)
    {
        if (isPlayed)
        {
            namePlate.gameObject.SetActive(false);
            traitsPlate.gameObject.SetActive(false);
            cardBackground.gameObject.SetActive(false);
            weaponPlate.gameObject.SetActive(false);

        }
        else 
        {
            if(TurnManager.instance.currentPlayerTurn == card.ownerID) 
            {
                image.raycastTarget = true;
                AnalyzePointerUp(eventData);
            }
            else
            {
               


            }
        }
    }
    
    private void AnalyzePointerUp(PointerEventData eventData)
    {


        if (eventData.pointerEnter != null && eventData.pointerEnter.name.Contains($"Player{card.ownerID + 1}PlayArea"))
        {
            if (PlayerManager.instance.FindPlayerByID(card.ownerID).playerSeals >= sealCost)
            {
                PlayCard(eventData.pointerEnter.transform);
                Initialize(card, TurnManager.instance.currentPlayerTurn);
                card.ownerID = TurnManager.instance.currentPlayerTurn;
                PlayerManager.instance.SpendMana(card.ownerID, card.sealCost);


                namePlate.gameObject.SetActive(false);
                traitsPlate.gameObject.SetActive(false);
                cardBackground.gameObject.SetActive(false);
                weaponPlate.gameObject.SetActive(false);

                isPlayed = true;
            }
            else
            {
                ReturnToHand();
            }

        }
        else
        {
            ReturnToHand();

        }
    }

    private void PlayCard(Transform playArea)
    {
        transform.SetParent(playArea);
        transform.localPosition = Vector3.zero;
        originalParent = playArea;
        CardManager.instance.PlayCard(this, card.ownerID);
        canAttack = false;
    }

    private void ReturnToHand()
    {
        transform.SetParent(originalParent);
        transform.localPosition = Vector3.zero;
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (transform.parent == originalParent) return;
        transform.position = eventData.position;

    }



    public void OnEndDrag(PointerEventData eventData)
    {
        if (isPlayed)
        {
            if (card.ownerID == TurnManager.instance.currentPlayerTurn)
            {
                if (eventData.pointerEnter.name == "CardPrefab(Clone)")
                {

                    eventData.pointerEnter.GetComponent<ThisCard>().namePlate.SetActive(true);

                    if (eventData.pointerDrag.GetComponent<ThisCard>().canAttack == true && eventData.pointerEnter.GetComponent<ThisCard>().isPlayed == true)
                    {

                        CardManager.Attack(eventData.pointerDrag, eventData.pointerEnter);

                    }
                    
                    else
                    {

                    }

                }
                
                else
                {

                }
            }
        }
        
        else
        {

        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
    }
}




