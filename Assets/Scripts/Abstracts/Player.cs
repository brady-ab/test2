using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class Player
{

    public int ID;
    public int playerHealth, playerSeals;
    public int arenaMasterID;
    public bool myTurn;
    public string arenaMasterName;

    public Player(int ID, int playerHealth, int playerSeals, int arenaMasterID, string arenaMasterName)
    {
        this.ID = ID;
        this.playerHealth = playerHealth;
        this.playerSeals = playerSeals;
        this.arenaMasterID = arenaMasterID;
        this.arenaMasterName = arenaMasterName;
    }

    public Player(int arenaMasterID, int playerealth, string arenaMasterName)
    {
        this.arenaMasterID = arenaMasterID;
        //this.playerHealth = playerHealth;
        this.arenaMasterName = arenaMasterName;

    }
}
