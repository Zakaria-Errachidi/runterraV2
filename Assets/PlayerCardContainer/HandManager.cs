using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class HandManager : MonoBehaviour
{
    public DeckManager DeckManager;
    public List<CardDefinition> Hand = new List<CardDefinition>();
    public UnityEvent<CardDefinition> OnCardAdded;

    public void AddCardToHand()
    {
        if (Hand.Count >= 5)
        {
            Debug.LogWarning("La main est pleine !");
            return;
        }
        CardDefinition def = DeckManager.PickRandom();


        Hand.Add(def);
        OnCardAdded?.Invoke(def);
    }
}
