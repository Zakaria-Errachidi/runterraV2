using UnityEngine;

public class GameBoardManager : MonoBehaviour
{
    public static GameBoardManager Instance;

    public Transform GrilleJoueur1;  // La grille du Joueur 1
    public Transform GrilleJoueur2;  // La grille du Joueur 2

    void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
    }
    /*
    public bool IsCorrectPlacement(Transform card, Transform targetGrid)
    {
        int currentPlayer = TurnSystem.Instance.GetCurrentPlayerIndex();

        // Vérifie si le joueur pose la carte dans la bonne grille
        if ((currentPlayer == 1 && targetGrid == GrilleJoueur1) ||
            (currentPlayer == 2 && targetGrid == GrilleJoueur2))
        {
            return true; // Placement valide
        }

        Debug.Log("❌ Vous ne pouvez pas poser de carte ici !");
        return false; // Placement invalide
    }*/
}
