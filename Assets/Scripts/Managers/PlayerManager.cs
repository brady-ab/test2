using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public static PlayerManager instance;
    public List<Player> players = new List<Player>();
    public List<ArenaMasterController> arenaMasters = new List<ArenaMasterController>();
    public GameObject amSelect;
    
    //AM MANAGER
    public ArenaMasterController amPrefab;

    public Transform Player1Portrait;
    public Transform Player2Portrait;

    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        UIManager.instance.UpdateValues(players[0], players[1]);
        amSelect.SetActive(true);

    }

    internal void AssignTurn(int currentPlayerTurn)
    {
        //FindPlayerByID(currentPlayerTurn).myTurn = true; He deleted this? IDK WHEN

        foreach(Player player in players)
        {

            player.myTurn = player.ID == currentPlayerTurn;
            if (player.myTurn) player.playerSeals = 10;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DamagePlayer(int ID, int damage)
    {
        Player player = FindPlayerByID(ID);
        player.playerHealth -= damage;
        if (player.playerHealth <= 0)
        {

        }
    }

    public Player FindPlayerByID(int ID)
    {
        Player foundPlayer = null;
        foreach (Player player in players)
        {
            if(player.ID == ID)
            foundPlayer = player;
        }
        return foundPlayer;
    }

    internal void SpendMana(int ownerID, int sealCost)
    {
        FindPlayerByID(ownerID).playerSeals -= sealCost;
        UIManager.instance.UpdateSealValues(players[0].playerSeals, players[1].playerSeals);
    }

    public void assignArenaMaster(int arenaMasterID, Player player)
    {
        if (player.ID == 0)
        {
            player.arenaMasterID = arenaMasterID;
            ArenaMasterController arenaMaster = Instantiate(amPrefab, Player1Portrait);
            arenaMasters.Add(arenaMaster);
            arenaMaster.transform.localPosition = Vector3.zero;
            Debug.Log(ArenaMasterDatabase.arenaMasterList[arenaMasterID]);
            arenaMaster.Initialize(ArenaMasterDatabase.arenaMasterList[arenaMasterID], TurnManager.instance.currentPlayerTurn);
            TurnManager.instance.EndTurn();

        }
        else if (player. ID == 1)
        {
            player.arenaMasterID = arenaMasterID;
            ArenaMasterController arenaMaster = Instantiate(amPrefab, Player2Portrait);
            arenaMasters.Add(arenaMaster);
            arenaMaster.transform.localPosition = Vector3.zero;
            Debug.Log(ArenaMasterDatabase.arenaMasterList[arenaMasterID]);
            arenaMaster.Initialize(ArenaMasterDatabase.arenaMasterList[arenaMasterID], TurnManager.instance.currentPlayerTurn);
            amSelect.SetActive(false);
            TurnManager.instance.EndTurn();
        }
    }

    
}
