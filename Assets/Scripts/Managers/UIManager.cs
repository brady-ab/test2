using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;
    public TextMeshProUGUI player0Health, player0Seals, player1Health, player1Seals;
    public Transform victoryScreen;

    private void Awake()
    {
        instance = this;
    }

    public void UpdateValues(Player player0, Player player1)
    {
        UpdateHealthValues(player0.playerHealth, player1.playerHealth);
        UpdateSealValues(player0.playerSeals, player1.playerSeals);
    }


    public void UpdateHealthValues(int player0Health, int player1Health)
    {
        this.player0Health.text = player0Health.ToString();
        this.player1Health.text = player1Health.ToString();

    }

    public void UpdateSealValues(int player0Seals, int player1Seals)
    {
        this.player0Seals.text = player0Seals.ToString();
        this.player1Seals.text = player1Seals.ToString();
    }
}
