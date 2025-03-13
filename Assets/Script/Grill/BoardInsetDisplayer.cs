using UnityEngine;
using UnityEngine.EventSystems;

public class BoardInsetDisplayer : MonoBehaviour, IPointerClickHandler
{
    private Transform currentCard = null; // Carte placée sur cette case

    public void OnPointerClick(PointerEventData eventData)
    {
        if (CardSelection.SelectedCard != null && currentCard == null)
        {
            Card selectedCard = CardSelection.SelectedCard.GetComponent<Card>();

            if (selectedCard != null)
            {
                int cardManaCost = selectedCard.GetManaCost();
                ScoreManager scoreManager = FindFirstObjectByType<ScoreManager>();

                if (scoreManager != null)
                {
                    int currentMana = scoreManager.GetCurrentPlayerMana();

                    if (currentMana >= cardManaCost)
                    {
                        // Vérifie que le joueur a assez de mana avant de poser la carte
                        scoreManager.ModifyPlayerMana(scoreManager.GetCurrentPlayerIndex(), -cardManaCost);
                        PlaceCard(selectedCard.transform);
                        CardSelection.DeselectCard();

                        // Exécute l'attaque après avoir posé la carte
                        AttackOpponent();
                    }
                    else
                    {
                        Debug.Log("Pas assez de mana pour poser cette carte.");
                    }
                }
            }
        }
    }

    private void PlaceCard(Transform card)
    {
        card.SetParent(transform);
        card.localPosition = Vector3.zero;
        card.localScale = Vector3.one;
        currentCard = card;
        Debug.Log("Carte placée sur la grille.");
    }

    private void AttackOpponent()
    {
        if (currentCard == null) return; // Pas de carte sur cette case

        Card attackingCard = currentCard.GetComponent<Card>();
        if (attackingCard == null) return;

        int attackDamage = attackingCard.GetDamage();

        // Recherche la case en face
        BoardInsetDisplayer opposingInset = FindOpposingInset();

        if (opposingInset != null && opposingInset.currentCard != null)
        {
            // Il y a une carte en face, elle est attaquée
            Card defendingCard = opposingInset.currentCard.GetComponent<Card>();

            if (defendingCard != null)
            {
                int defendingHP = defendingCard.GetHealth();

                // Dégâts limités aux HP de la carte adverse
                int damageDealt = Mathf.Min(attackDamage, defendingHP);
                defendingCard.TakeDamage(damageDealt);

                // Vérifie si la carte adverse est détruite
                if (defendingCard.GetHealth() <= 0)
                {
                    Destroy(defendingCard.gameObject);
                    opposingInset.currentCard = null;
                }

                Debug.Log($"Attaque réussie : {damageDealt} dégâts infligés à la carte adverse.");
            }
        }
        else
        {
            // Aucune carte en face, attaque directement le joueur adverse
            ScoreManager scoreManager = FindFirstObjectByType<ScoreManager>();
            if (scoreManager != null)
            {
                int opponentIndex = (scoreManager.GetCurrentPlayerIndex() == 0) ? 1 : 0;
                int finalDamage = attackDamage * 2;
                scoreManager.ModifyPlayerHP(opponentIndex, -finalDamage);

                Debug.Log($"Aucune carte en face, {finalDamage} dégâts infligés au joueur adverse.");
            }
        }
    }

    private BoardInsetDisplayer FindOpposingInset()
    {
        // Recherche la case adverse en fonction de la grille
        Transform parent = transform.parent; // Ligne actuelle
        Transform gridContainer = parent.parent; // Grille complète

        foreach (Transform row in gridContainer)
        {
            if (row != parent) // Vérifie les autres lignes
            {
                foreach (Transform inset in row)
                {
                    BoardInsetDisplayer insetDisplayer = inset.GetComponent<BoardInsetDisplayer>();
                    if (insetDisplayer != null && insetDisplayer.transform.position.x == transform.position.x)
                    {
                        return insetDisplayer; // Retourne la case en face
                    }
                }
            }
        }
        return null; // Aucune case adverse trouvée
    }
}
