using UnityEngine;
using UnityEngine.EventSystems;

public class BoardInsetDisplayer : MonoBehaviour, IPointerClickHandler
{
    private Transform currentCard = null; // Stocke la carte placée ici

    public void OnPointerClick(PointerEventData eventData)
    {
        if (CardSelection.SelectedCard != null && currentCard == null)
        {
            // Vérifier si l'Inset appartient bien à MyHand
            if (IsInsideMyHand())
            {
                PlaceCard(CardSelection.SelectedCard.transform);
                CardSelection.DeselectCard();
            }
            else
            {
                Debug.Log("Impossible de poser une carte dans la zone adverse !");
            }
        }
    }

    private void PlaceCard(Transform card)
    {
        card.SetParent(transform); // Attache la carte à cette case
        card.localPosition = Vector3.zero; // Centre la carte sur la case
        card.localScale = Vector3.one; // Ajuste l'échelle si besoin
        currentCard = card; // Stocke la carte placée
        Debug.Log("Carte placée !");
    }

    private bool IsInsideMyHand()
    {
        Transform parent = transform.parent; // Commence par le parent immédiat

        while (parent != null) // Remonte dans la hiérarchie
        {
            if (parent.name == "MyHand") return true; // Si MyHand est trouvé, c'est bon
            if (parent.name == "J1") return false; // Si c'est J1, on refuse
            parent = parent.parent; // Continue à remonter
        }

        return false; // Si on ne trouve ni MyHand ni J1, refuse le placement
    }
}
