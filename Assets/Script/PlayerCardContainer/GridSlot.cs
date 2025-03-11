using UnityEngine;
using UnityEngine.EventSystems;

public class GridSlot : MonoBehaviour, IDropHandler, IPointerClickHandler
{
    public bool isEmpty = true;

    public void OnDrop(PointerEventData eventData)
    {
        DragDrop card = eventData.pointerDrag.GetComponent<DragDrop>();

        if (card != null && isEmpty)
        {
            card.transform.SetParent(transform);
            card.transform.localPosition = Vector3.zero;
            isEmpty = false;
            DragDrop.ClearSelection(); // D�s�lectionner apr�s drop
        }
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        DragDrop card = DragDrop.GetSelectedCard();

        if (card != null && isEmpty)
        {
            card.transform.SetParent(transform);
            card.transform.localPosition = Vector3.zero;
            isEmpty = false;
            DragDrop.ClearSelection();
        }
    }
}
