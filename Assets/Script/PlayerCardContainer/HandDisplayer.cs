using UnityEngine;
using UnityEngine.UI;

public class HandDisplayer : MonoBehaviour
{
    public HorizontalLayoutGroup CardLayoutGroupJ1;
    public HorizontalLayoutGroup CardLayoutGroupJ2;
    public HandManager HandManager;

    void Start()
    {
        HandManager.OnCardAdded.AddListener(UpdateDisplayer); // 🔥 Écoute les nouvelles cartes
        UpdateDisplayer(1);
        UpdateDisplayer(2);
    }

    public void UpdateDisplayer(int playerIndex)
    {
        HorizontalLayoutGroup targetContainer = (playerIndex == 1) ? CardLayoutGroupJ1 : CardLayoutGroupJ2;

        foreach (Transform child in targetContainer.transform)
        {
            Destroy(child.gameObject);
        }

        foreach (CardDefinition CardDef in HandManager.GetHand(playerIndex))
        {
            Card newCard = Instantiate(Resources.Load<Card>("CardPrefab"), targetContainer.transform);
            newCard.Initialize(CardDef);
        }
    }
}
