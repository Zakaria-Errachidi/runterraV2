using UnityEngine;
using UnityEngine.EventSystems;

public class CardSelection : MonoBehaviour, IPointerClickHandler
{
    public static CardSelection SelectedCard { get; private set; } // Stocke la carte sélectionnée

    public void OnPointerClick(PointerEventData eventData)
    {
        if (SelectedCard == this)
        {
            DeselectCard();
            Debug.Log("Carte désélectionnée.");
        }
        else
        {
            SelectedCard = this;
            Debug.Log("Carte sélectionnée : " + gameObject.name);
        }
    }

    public static void DeselectCard()
    {
        SelectedCard = null;
    }
}
