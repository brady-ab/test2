using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using UnityEngine.UI;

public class GameplayUIController : MonoBehaviour
{

    public TextMeshProUGUI currentPlayerTurn;
    public static GameplayUIController instance;
    public Button endTurn;

    private void Awake()
    {
        instance = this;
        SetupButtons();
    }

    private void SetupButtons()
    {
        endTurn.onClick.AddListener(() =>
        {
            TurnManager.instance.EndTurn();
        });
    }

    public void UpdateCurrentPlayerTurn(int ID)
    {
        currentPlayerTurn.gameObject.SetActive(true);
        currentPlayerTurn.text = $"Player {ID + 1}'s Turn!";

        StartCoroutine(BlinkCurrentPlayerTurn());
    }

    private IEnumerator BlinkCurrentPlayerTurn()
    {
        yield return new WaitForSeconds(0.5f);
        currentPlayerTurn.gameObject.SetActive(false);
        yield return new WaitForSeconds(0.5f);
        currentPlayerTurn.gameObject.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        currentPlayerTurn.gameObject.SetActive(false);
        //yield return new WaitForSeconds(0.5f);
        //currentPlayerTurn.gameObject.SetActive(true);
        //yield return new WaitForSeconds(0.5f);
        //currentPlayerTurn.gameObject.SetActive(false);

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
