using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    [Header("R�f�rences UI")]
    public TMP_Text[] playerUsernames;
    public TMP_Text[] playerHealthText;
    public TMP_Text[] playerManaText;

    [Header("Configuration des joueurs")]
    public string[] playerNames = { "Joueur 1", "Joueur 2", "Joueur 3", "Joueur 4" };
    private int[] playerHP = { 20, 20, 20, 20 };
    private int[] playerMana = { 4, 1, 1, 1 };
    private int maxPlayers = 4;

    [Header("Gestion des Canvas")]
    public GameObject battleBoardCanvas;  // Canvas o� se trouve le bouton "Surrender"
    public GameObject waitingRoomCanvas;  // Canvas o� le joueur est redirig� apr�s surrender

    void Start()
    {
        UpdateScoreUI();
    }

    private void UpdateScoreUI()
    {
        for (int i = 0; i < maxPlayers; i++)
        {
            if (i < playerUsernames.Length)
            {
                playerUsernames[i].text = playerNames[i];
                playerHealthText[i].text = "HP: " + playerHP[i];
                playerManaText[i].text = "Mana: " + playerMana[i];
            }
        }
    }

    public void ModifyPlayerHP(int playerIndex, int amount)
    {
        if (playerIndex >= 0 && playerIndex < maxPlayers)
        {
            playerHP[playerIndex] += amount;
            UpdateScoreUI();
        }
    }

    public void ModifyPlayerMana(int playerIndex, int amount)
    {
        if (playerIndex >= 0 && playerIndex < maxPlayers)
        {
            playerMana[playerIndex] += amount;
            UpdateScoreUI();
        }
    }

    public void Surrender(int playerIndex)
    {
        if (playerIndex >= 0 && playerIndex < maxPlayers)
        {
            Debug.Log(playerNames[playerIndex] + " s'est rendu ! Redirection vers la Waiting Room...");
            playerHP[playerIndex] = 0;
            playerMana[playerIndex] = 0;
            UpdateScoreUI();

            //D�sactiver le BattleBoard et Activer la Waiting Room
            battleBoardCanvas.SetActive(false);
            waitingRoomCanvas.SetActive(true);
        }
    }
    public int GetPlayerHP(int index)
    {
        return (index >= 0 && index < maxPlayers) ? playerHP[index] : 0;
    }

    public int GetPlayerMana(int index)
    {
        return (index >= 0 && index < maxPlayers) ? playerMana[index] : 0;
    }
    public int GetCurrentPlayerIndex()
    {
        // Retourne l'index du joueur actif (� adapter si besoin)
        return 0; // 0 pour Joueur 1, 1 pour Joueur 2...
    }

    public int GetCurrentPlayerMana()
    {
        int playerIndex = GetCurrentPlayerIndex();
        return playerMana[playerIndex];
    }


}
