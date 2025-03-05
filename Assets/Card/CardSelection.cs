using UnityEngine;
using UnityEngine.EventSystems;

public class CardSelection : MonoBehaviour, IPointerClickHandler
{
    public static CardSelection SelectedCard { get; private set; } // Stocke la carte s�lectionn�e

    public void OnPointerClick(PointerEventData eventData)
    {
        if (SelectedCard == this)
        {
            DeselectCard();
            Debug.Log("Carte d�s�lectionn�e.");
        }
        else
        {
            SelectedCard = this;
            Debug.Log("Carte s�lectionn�e : " + gameObject.name);
        }
    }

    public static void DeselectCard()
    {
        SelectedCard = null;
    }
}
