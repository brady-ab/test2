using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
[System.Serializable]

public class Card
{
    public int id;
    public int ownerID;
    
    public GameObject namePlate;

    public bool isPlayed;

    public string cardName;
    public int sealCost;
    public int attackDamage;
    public int cardHealth;
    public string traits;

    public Sprite illustration;

    public Card()
    {

    }

    public Card(ThisCard c)
    {
        cardName = c.cardName;
        sealCost = c.sealCost;
        attackDamage = c.attackDamage;
        cardHealth = c.cardHealth;
        traits = c.traits;

        isPlayed = c.isPlayed;
        id = c.id;
        ownerID = c.ownerID;
    }



    //public Card(int Id, string CardName, int SealCost, int AttackDamage, int CardHealth, string Traits)
    //{
    //    id = Id;
    //    cardName = CardName;
    //    sealCost = SealCost;
    //    attackDamage = AttackDamage;
    //    cardHealth = CardHealth;
    //    traits = Traits;

    //}

    public Card(int id, string cardname, int sealcost, int attackdamage, int cardhealth, string traits, Sprite illustration)
    {
        this.id = id;
       
        cardName = cardname;
        sealCost = sealcost;
        attackDamage = attackdamage;
        cardHealth = cardhealth;
        this.traits = traits;
        this.illustration = illustration;
    }

    public Card(Card card)
    {
        cardName = card.cardName;
        cardHealth = card.cardHealth;
        attackDamage = card.attackDamage;
        sealCost = card.sealCost;
        traits = card.traits;
        illustration = card.illustration;
        isPlayed = card.isPlayed;
        
    }
}

