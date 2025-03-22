using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TurnSystem : MonoBehaviour
{
    public static TurnSystem Instance;

    private int currentPlayer = 1; // 1 = Joueur 1, 2 = Joueur 2
    private bool gameStarted = false;
    private int playersReady = 0; // Suivi des joueurs prêts

    public TMP_Text TurnText;
    public Button ReadyButton;
    public Button EndTurnButton;

    void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
    }

    void Start()
    {
        UpdateTurnUI();
        ReadyButton.onClick.AddListener(PlayerReady);
        EndTurnButton.onClick.AddListener(EndTurn);
    }

    private void UpdateTurnUI()
    {
        if (!gameStarted)
        {
            TurnText.text = "📌 Attente des joueurs...";
        }
        else
        {
            TurnText.text = $"🎯 Tour du Joueur {currentPlayer}";
        }
    }

    public void PlayerReady()
    {
        playersReady++;
        if (playersReady >= 2) // Attendre que les deux joueurs soient prêts
        {
            gameStarted = true;
            Debug.Log("🚀 Début du combat !");
        }
        UpdateTurnUI();
    }

    public bool HasGameStarted()
    {
        return gameStarted;
    }

    public void EndTurn()
    {
        currentPlayer = (currentPlayer == 1) ? 2 : 1;
        UpdateTurnUI();
    }

    public int GetCurrentPlayerIndex()
    {
        Debug.Log($"🎲 Joueur Actuel: {currentPlayer}");
        return currentPlayer;
    }

}
