using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR;

public class HandDisplayer : MonoBehaviour
{
    public HorizontalLayoutGroup CardLayoutGroup;
    public Card PrefabCardDisplayer;
    public HandManager HandManager;

    void Start()
    {
        HandManager.OnCardAdded.AddListener(_ => UpdateDisplayer());
        UpdateDisplayer();
    }

    public void UpdateDisplayer()
    {
        
        // Nettoyer les anciennes cartes
        foreach (Transform child in CardLayoutGroup.transform)
        {
            Destroy(child.gameObject);
        }
        // Ajouter et positionner les nouvelles cartes
        foreach (CardDefinition CardDef in HandManager.Hand)
        {
            Debug.Log("carte ajoute");
            Card newCard = Instantiate(PrefabCardDisplayer, CardLayoutGroup.transform);
            newCard.initialize(CardDef);
        }
    }
}
