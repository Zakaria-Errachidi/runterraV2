using UnityEngine;
using UnityEngine.EventSystems;

public class DragDrop : MonoBehaviour
{
    private Transform parentBeforeDrag;
    private CanvasGroup canvasGroup;
    private RectTransform rectTransform;
    private static DragDrop selectedCard = null; // Pour le Click & Place

    private void Awake()
    {
        canvasGroup = GetComponent<CanvasGroup>();
        rectTransform = GetComponent<RectTransform>();
    }

    // Gestion du Drag & Drop
    public void OnBeginDrag(PointerEventData eventData)
    {
        parentBeforeDrag = transform.parent;
        transform.SetParent(transform.root);
        canvasGroup.blocksRaycasts = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        rectTransform.anchoredPosition += eventData.delta / transform.lossyScale.x;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        canvasGroup.blocksRaycasts = true;
        transform.SetParent(parentBeforeDrag);
    }

    // Gestion du Click & Place
    public void OnPointerClick(PointerEventData eventData)
    {
        if (selectedCard == this)
        {
            selectedCard = null;
            Debug.Log("Carte désélectionnée.");
        }
        else
        {
            selectedCard = this;
            Debug.Log("Carte sélectionnée: " + name);
        }
    }

    public static DragDrop GetSelectedCard()
    {
        return selectedCard;
    }

    public static void ClearSelection()
    {
        selectedCard = null;
    }
}
