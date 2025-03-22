using UnityEngine;
using System.Collections.Generic;

public class CardDisplayManager : MonoBehaviour
{
    public GameObject cardPrefab;  // La prefab de carte
    public Transform contentPanel; // Référence au Content du ScrollView
    public List<CardDefinition> allCards; // Liste des cartes à afficher

    void Start()
    {
        DisplayAllCards();
    }

    void DisplayAllCards()
    {
        foreach (var cardDefinition in allCards)
        {
            GameObject newCard = Instantiate(cardPrefab, contentPanel);
            Card newCardScript = newCard.GetComponent<Card>();  // Récupère le script `card`
            newCardScript.Initialize(cardDefinition); // Initialise avec les données
            Debug.Log("Carte ajoutée : " + cardDefinition.cardName);
        }
    }
}
