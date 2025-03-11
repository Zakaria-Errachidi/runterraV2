using UnityEngine;
    using UnityEngine.EventSystems;

    public class CardHoverEffect : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
    {
        private Vector3 originalPosition; // La vraie position de la carte au moment du hover
        private float hoverHeight = 200f; // Hauteur du hover
        private float speed = 10f; // Vitesse de transition
        private bool isHovering = false; // Empêche les mouvements en boucle

        void Start()
        {
            // Enregistre la position de la carte dès son placement dans CardContainer
            originalPosition = transform.localPosition;
        }

        public void OnPointerEnter(PointerEventData eventData)
        {
            if (!isHovering)
            {
                isHovering = true;
                originalPosition = transform.localPosition; // Met à jour la position AVANT de monter
                StopAllCoroutines();
                StartCoroutine(MoveCard(originalPosition + new Vector3(0, hoverHeight, 0)));
            }
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            if (isHovering)
            {
                isHovering = false;
                StopAllCoroutines();
                StartCoroutine(MoveCard(originalPosition)); // Retourne exactement où elle était avant le hover
            }
        }

        private System.Collections.IEnumerator MoveCard(Vector3 targetPosition)
        {
            while (Vector3.Distance(transform.localPosition, targetPosition) > 0.1f)
            {
                transform.localPosition = Vector3.Lerp(transform.localPosition, targetPosition, Time.deltaTime * speed);
                yield return null;
            }
            transform.localPosition = targetPosition;
        }
    }
