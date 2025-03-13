using UnityEngine;
using TMPro;

public class WaitingRoomManager : MonoBehaviour
{
    [Header("R�f�rences UI - Waiting Room")]
    public TMP_Text[] finalPlayerUsernames;
    public TMP_Text[] finalPlayerHealth;
    public TMP_Text[] finalPlayerMana;

    private ScoreManager scoreManager;

    void Start()
    {
        // Cache le WaitingRoomCanvas au d�but
        gameObject.SetActive(false);

        // Trouve ScoreManager actif dans la sc�ne
        scoreManager = FindFirstObjectByType<ScoreManager>();
    }

    public void UpdateFinalScores()
    {
        if (scoreManager == null)
        {
            Debug.LogError(" ScoreManager non trouv� !");
            return;
        }

        for (int i = 0; i < finalPlayerUsernames.Length; i++)
        {
            finalPlayerUsernames[i].text = scoreManager.playerNames[i];
            finalPlayerHealth[i].text = "HP: " + scoreManager.GetPlayerHP(i);
            finalPlayerMana[i].text = "Mana: " + scoreManager.GetPlayerMana(i);
        }
    }
}
