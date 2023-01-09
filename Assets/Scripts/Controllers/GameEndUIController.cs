using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System;

public class GameEndUIController : MonoBehaviour
{

    public TextMeshProUGUI winnerName;
    public Button restart, quit;
    public GameEndUIController gameEndUI;

    public void Initialize(Player winner)
    {
        winnerName.text = "Player: " + winner.ID + " has won!";
    }

    private void Awake()
    {
        SetupButtons();
    }

    public void GameFinished(Player winner)
    {
        gameEndUI.gameObject.SetActive(true);
        gameEndUI.Initialize(winner);
    }

    private void SetupButtons()
    {

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
