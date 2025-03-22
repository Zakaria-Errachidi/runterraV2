using UnityEngine;
using System.Collections.Generic;

public class CardDisplayManager : MonoBehaviour
{
    public GameObject cardPrefab;  // La prefab de carte
    public Transform contentPanel; // R�f�rence au Content du ScrollView
    public List<CardDefinition> allCards; // Liste des cartes � afficher

    void Start()
    {
        DisplayAllCards();
    }

    void DisplayAllCards()
    {
        foreach (var cardDefinition in allCards)
        {
            GameObject newCard = Instantiate(cardPrefab, contentPanel);
            Card newCardScript = newCard.GetComponent<Card>();  // R�cup�re le script `card`
            newCardScript.Initialize(cardDefinition); // Initialise avec les donn�es
            Debug.Log("Carte ajout�e : " + cardDefinition.cardName);
        }
    }
}
