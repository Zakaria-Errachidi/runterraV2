using UnityEngine;
using UnityEngine.EventSystems;

public class CardSelection : MonoBehaviour, IPointerClickHandler
{
    public static CardSelection SelectedCard { get; private set; }
    public static Transform SelectedCardParent { get; private set; } // Stocke le parent de la carte sélectionnée


    public void OnPointerClick(PointerEventData eventData)
    {
        if (SelectedCard == this)
        {
            DeselectCard();
        }
        else
        {
            if (SelectedCard != null)
            {
                DeselectCard();
            }

            SelectedCard = this;
            SelectedCardParent = transform.parent; // 🔥 Stocke le parent de la carte

            Debug.Log($"✅ Carte sélectionnée : {gameObject.name}, Parent : {SelectedCardParent.name}");
        }
    }

    public static void DeselectCard()
    {
        SelectedCard = null;
        SelectedCardParent = null; // 🔥 Réinitialise le parent
    }

}
