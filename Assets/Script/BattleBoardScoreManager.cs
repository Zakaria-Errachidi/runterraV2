/*
using UnityEngine;
using TMPro;

public class BattleBoardScoreManager : MonoBehaviour
{
    [Header("Références UI - BattleBoard")]
    public TMP_Text player1Username_BB;
    public TMP_Text player1Health_BB;
    public TMP_Text player1Mana_BB;
    public TMP_Text player2Username_BB;
    public TMP_Text player2Health_BB;
    public TMP_Text player2Mana_BB;

    private string player1Name = "Joueur 1";
    private string player2Name = "Joueur 2";
    private int player1HP_BB = 20;
    private int player2HP_BB = 20;
    private int player1Mana_BB = 1;
    private int player2Mana_BB = 1;

    public GameObject battleBoardCanvas;
    public GameObject waitingRoomCanvas;

    void Start()
    {
        UpdateScoreUI();
    }

    private void UpdateScoreUI()
    {
        player1Username_BB.text = player1Name;
        player1Health_BB.text = "HP: " + player1HP_BB;
        player1Mana_BB.text = "Mana: " + player1Mana_BB;

        player2Username_BB.text = player2Name;
        player2Health_BB.text = "HP: " + player2HP_BB;
        player2Mana_BB.text = "Mana: " + player2Mana_BB;
    }

    public void ModifyPlayer1HP(int amount)
    {
        player1HP_BB += amount;
        UpdateScoreUI();
    }

    public void ModifyPlayer2HP(int amount)
    {
        player2HP_BB += amount;
        UpdateScoreUI();
    }

    public void ModifyPlayer1Mana(int amount)
    {
        player1Mana_BB += amount;
        UpdateScoreUI();
    }

    public void ModifyPlayer2Mana(int amount)
    {
        player2Mana_BB += amount;
        UpdateScoreUI();
    }

    public void Surrender(int playerIndex)
    {
        if (playerIndex == 1)
        {
            Debug.Log("Joueur 1 s'est rendu. Passage à la salle d'attente...");
            player1HP_BB = 0;
            player1Mana_BB = 0;
        }
        else if (playerIndex == 2)
        {
            Debug.Log("Joueur 2 s'est rendu. Passage à la salle d'attente...");
            player2HP_BB = 0;
            player2Mana_BB = 0;
        }

        UpdateScoreUI();
        battleBoardCanvas.SetActive(false);
        waitingRoomCanvas.SetActive(true);
    }

    // ✅ Ajout des getters pour récupérer les valeurs
    public int GetPlayer1HP_BB() { return player1HP_BB; }
    public int GetPlayer1Mana_BB() { return player1Mana_BB; }
    public int GetPlayer2HP_BB() { return player2HP_BB; }
    public int GetPlayer2Mana_BB() { return player2Mana_BB; }
}
*/