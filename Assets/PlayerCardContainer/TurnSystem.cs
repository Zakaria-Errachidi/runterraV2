using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TurnSystem : MonoBehaviour
{
    public bool IsYourTurn = true; 
    public int TurnNumber = 1;
    public TMP_Text TurnText;
    public TMP_Text MancheText; 
    public Button EndTurnButton;

    public int MaxMana = 1;
    public int CurrentMana = 1;

    void Start()
    {
        UpdateTurnUI(); // Met � jour l'affichage d�s le d�but
        EndTurnButton.onClick.AddListener(EndTurn); // Lie le bouton � la fonction EndTurn()
    }

    void UpdateTurnUI()
    {
        TurnText.text = IsYourTurn ? "Your Turn" : "Opponent Turn";
        MancheText.text = CurrentMana + "/" + MaxMana;
    }

    public void EndTurn()
    {
        IsYourTurn = !IsYourTurn; // Change de joueur
        TurnNumber++;

        if (IsYourTurn) // Si c'est le tour du joueur
        {
            MaxMana++; // Augmente le maximum de mana
            CurrentMana = MaxMana; // R�g�n�re le mana
        }

        UpdateTurnUI(); // Met � jour l'affichage
    }
}
