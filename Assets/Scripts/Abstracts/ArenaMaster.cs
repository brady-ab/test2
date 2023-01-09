using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]

public class ArenaMaster
{
    public int ID;
    public int playerHealth, playerSeals;
    public bool myTurn;
    public string arenaMasterName;

    public ArenaMaster(int ID, int amHealth, int playerSeals, string arenaMasterName)
    {
        this.ID = ID;
        this.playerHealth = amHealth;
        this.playerSeals = playerSeals;
        this.arenaMasterName = arenaMasterName;
    }

    public ArenaMaster(ArenaMasterController amc)
    {
        ID = amc.ID;
        playerHealth = amc.currentHealth;
        playerSeals = amc.currentSeals;
        arenaMasterName = amc.arenaMasterName;

    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
