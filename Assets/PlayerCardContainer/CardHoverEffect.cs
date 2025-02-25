using UnityEngine;
using UnityEngine.EventSystems;

public class CardHoverEffect : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    private Vector3 originalScale;
    private Vector3 originalPosition;
    public float hoverScaleFactor = 1.3f; // Taille augment�e au survol
    public float hoverMoveUp = 150f; // Distance de mont�e au survol

    void Start()
    {
        originalScale = transform.localScale;
        originalPosition = transform.position;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        // Agrandir et d�placer vers le haut
        transform.localScale = originalScale * hoverScaleFactor;
        transform.position = new Vector3(originalPosition.x, originalPosition.y + hoverMoveUp, originalPosition.z);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        // Revenir � la position et taille normales
        transform.localScale = originalScale;
        transform.position = originalPosition;
    }
}
