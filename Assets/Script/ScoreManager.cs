using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class ScoreManager : MonoBehaviour
{
    [Header("Références UI")]
    public TMP_Text[] playerUsernames;
    public TMP_Text[] playerHealthText;
    public TMP_Text[] playerManaText;

    [Header("Configuration des joueurs")]
    public string[] playerNames = { "Joueur 1", "Joueur 2", "Joueur 3", "Joueur 4" };
    private int[] playerHP = { 20, 20, 20, 20 };
    private int[] playerMana = { 8, 8, 8, 8 };
    private int maxPlayers = 4;

    [Header("UI de Fin de Partie")]
    public GameObject battleBoardCanvas;
    public GameObject endGameCanvas;
    public TMP_Text winnerText;
    public UnityEngine.UI.Button quitButton;


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

            // Limite les HP à minimum 0
            playerHP[playerIndex] = Mathf.Max(0, playerHP[playerIndex]);

            UpdateScoreUI();

            // Vérifie si le joueur est mort
            if (playerHP[playerIndex] <= 0)
            {
                Debug.Log(playerNames[playerIndex] + " a perdu !");
                EndGame(playerIndex);
            }
        }
    }


    public void ModifyPlayerMana(int playerIndex, int amount)
    {
        if (playerIndex >= 0 && playerIndex < maxPlayers)
        {
            playerMana  [playerIndex] += amount;
            UpdateScoreUI();
        }
    }

    private void EndGame(int loserIndex)
    {
        int winnerIndex = (loserIndex == 0) ? 1 : 0;

        Debug.Log("Partie terminée ! " + playerNames[winnerIndex] + " gagne !");

        // Désactive le canvas principal
        battleBoardCanvas.SetActive(false);

        // Active le canvas de fin
        endGameCanvas.SetActive(true);

        // Met à jour le texte du gagnant
        winnerText.text = playerNames[winnerIndex] + " a gagné la partie !";

        // Ajoute l'action du bouton pour quitter
        quitButton.onClick.RemoveAllListeners();
        quitButton.onClick.AddListener(() =>
        {
            SceneManager.LoadSceneAsync("Start");
        });
    }





    public void Surrender(int playerIndex)
    {
        if (playerIndex >= 0 && playerIndex < maxPlayers)
        {
            Debug.Log(playerNames[playerIndex] + " s'est rendu ! Redirection vers la Waiting Room...");
            playerHP[playerIndex] = 0;
            playerMana[playerIndex] = 0;
            UpdateScoreUI();
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

}
