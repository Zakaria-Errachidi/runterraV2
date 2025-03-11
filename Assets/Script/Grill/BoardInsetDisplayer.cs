using UnityEngine;
using UnityEngine.EventSystems;

public class BoardInsetDisplayer : MonoBehaviour, IPointerClickHandler
{
    private Transform currentCard = null; // Stocke la carte plac�e ici

    public void OnPointerClick(PointerEventData eventData)
    {
        if (CardSelection.SelectedCard != null && currentCard == null)
        {
            // V�rifier si l'Inset appartient bien � MyHand
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
        card.SetParent(transform); // Attache la carte � cette case
        card.localPosition = Vector3.zero; // Centre la carte sur la case
        card.localScale = Vector3.one; // Ajuste l'�chelle si besoin
        currentCard = card; // Stocke la carte plac�e
        Debug.Log("Carte plac�e !");
    }

    private bool IsInsideMyHand()
    {
        Transform parent = transform.parent; // Commence par le parent imm�diat

        while (parent != null) // Remonte dans la hi�rarchie
        {
            if (parent.name == "MyHand") return true; // Si MyHand est trouv�, c'est bon
            if (parent.name == "J1") return false; // Si c'est J1, on refuse
            parent = parent.parent; // Continue � remonter
        }

        return false; // Si on ne trouve ni MyHand ni J1, refuse le placement
    }
}
