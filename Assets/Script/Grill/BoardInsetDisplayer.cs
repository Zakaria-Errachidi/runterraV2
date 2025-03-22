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
                    int currentPlayerIndex;

                    // 🔥 Même logique que l'attaque : déterminer qui joue la carte
                    if (CardSelection.SelectedCardParent != null && CardSelection.SelectedCardParent.name.Contains("CardContainer"))
                    {
                        currentPlayerIndex = 0; // J1 joue la carte
                    }
                    else if (CardSelection.SelectedCardParent != null && CardSelection.SelectedCardParent.name.Contains("CardContainerAgainst"))
                    {
                        currentPlayerIndex = 1; // J2 joue la carte
                    }
                    else
                    {
                        Debug.LogError("❌ Erreur : Impossible de déterminer le joueur qui joue la carte.");
                        return;
                    }

                    PlaceCard(selectedCard.transform);
                    CardSelection.DeselectCard();
                    AttackOpponent();

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
        if (currentCard == null) return;

        Card attackingCard = currentCard.GetComponent<Card>();
        if (attackingCard == null) return;

        int attackDamage = attackingCard.GetDamage();
        int cardManaCost = attackingCard.GetManaCost();

        ScoreManager scoreManager = FindFirstObjectByType<ScoreManager>();
        if (scoreManager == null) return;

        int currentPlayerIndex;

        if (attackingCard.transform.parent.parent.parent.parent.name.Contains("MyHand"))
        {
            currentPlayerIndex = 0;
        }
        else if (attackingCard.transform.parent.parent.parent.parent.name.Contains("J1"))
        {
            currentPlayerIndex = 1;
        }
        else
        {
            Debug.LogError("Impossible de déterminer l’origine de la carte.");
            return;
        }

        int currentMana = scoreManager.GetPlayerMana(currentPlayerIndex);

        if (currentMana < cardManaCost)
        {
            Debug.Log("Pas assez de mana pour attaquer.");
            return;
        }

        scoreManager.ModifyPlayerMana(currentPlayerIndex, -cardManaCost);

        // Recherche la case en face
        BoardInsetDisplayer opposingInset = FindOpposingInset();

        if (opposingInset != null && opposingInset.currentCard != null)
        {
            Card defendingCard = opposingInset.currentCard.GetComponent<Card>();
            if (defendingCard != null)
            {
                int defendingHP = defendingCard.GetHealth();
                int damageDealt = Mathf.Min(attackDamage, defendingHP);
                defendingCard.TakeDamage(damageDealt);

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
            int opponentIndex = currentPlayerIndex == 0 ? 1 : 0;
            int finalDamage = attackDamage * 2;
            scoreManager.ModifyPlayerHP(opponentIndex, -finalDamage);
            Debug.Log($"Attaque directe : {finalDamage} dégâts infligés au Joueur {opponentIndex + 1}.");
        }

        DestroyCard(attackingCard);
    }



    private void DestroyCard(Card attackingCard)
    {
        if (currentCard != null)
        {
            HandManager handManager = FindFirstObjectByType<HandManager>();

            if (handManager != null)
            {
                int playerIndex;
                if (attackingCard.transform.parent.parent.parent.parent.name.Contains("MyHand"))
                {
                    playerIndex = 1;
                }
                else if (attackingCard.transform.parent.parent.parent.parent.name.Contains("J1"))
                {
                    playerIndex = 2;
                }
                else
                {
                    Debug.LogError("❌ Impossible de déterminer à quel joueur appartient la carte !");
                    return;
                }

                handManager.RemoveCardFromHand(playerIndex, attackingCard);
                Debug.Log($"🃏 Carte retirée de la main du Joueur {playerIndex}");
            }

            Debug.Log($"🔥 Carte {currentCard.gameObject.name} détruite après 2 secondes !");
            Destroy(currentCard.gameObject, 2f); // Détruit la carte après 2 secondes
            currentCard = null; // Libère l'emplacement après la destruction
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