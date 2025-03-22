using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class HandManager : MonoBehaviour
{
    public DeckManager DeckManager;
    private List<CardDefinition>[] hands = new List<CardDefinition>[2] { new List<CardDefinition>(), new List<CardDefinition>() };

    public UnityEvent<int> OnCardAdded = new UnityEvent<int>(); // 🔥 Événement pour signaler une carte ajoutée

    public void AddCardToHand(int playerIndex)
    {
        if (playerIndex != 1 && playerIndex != 2) return; // Vérifie que seul J1 et J2 jouent

        if (hands[playerIndex - 1].Count >= 5)
        {
            Debug.Log("❌ Main pleine !");
            return;
        }

        CardDefinition def = DeckManager.PickRandom();
        hands[playerIndex - 1].Add(def);

        OnCardAdded.Invoke(playerIndex); // Notifie que la main d'un joueur a changé
    }

    public void RemoveCardFromHand(int playerIndex, Card cardToRemove)
    {
        if (playerIndex != 1 && playerIndex != 2) return; // Vérifie que seul J1 et J2 jouent

        List<CardDefinition> hand = hands[playerIndex - 1];

        // Cherche la carte à supprimer
        CardDefinition cardDefinition = cardToRemove.GetComponent<Card>().GetCardDefinition();

        if (hand.Contains(cardDefinition))
        {
            hand.Remove(cardDefinition);
            Debug.Log($"✅ Carte {cardDefinition.cardName} retirée de la main du Joueur {playerIndex}");
        }
        else
        {
            Debug.LogWarning("❌ La carte à supprimer n'a pas été trouvée dans la main !");
        }
    }


    public List<CardDefinition> GetHand(int playerIndex)
    {
        return hands[playerIndex - 1];
    }
}
