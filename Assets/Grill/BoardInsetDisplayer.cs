using UnityEngine;
using UnityEngine.EventSystems;

public class BoardInsetDisplayer : MonoBehaviour, IPointerClickHandler
{
    private Transform currentCard = null; // Stocke la carte plac�e ici

    public void OnPointerClick(PointerEventData eventData)
    {
        if (CardSelection.SelectedCard != null && currentCard == null)
        {
            PlaceCard(CardSelection.SelectedCard.transform);
            CardSelection.DeselectCard();
        }
    }


    private void PlaceCard(Transform card)
    {
        card.SetParent(transform); // Attache la carte � cette case
        card.localPosition = Vector3.zero; // Centre la carte sur la case
        card.localScale = Vector3.one; // Ajuste l'�chelle si besoin
        currentCard = card; // Stocke la carte plac�e
        Debug.Log("Carte plac�e sur la grille !");
    }
}
