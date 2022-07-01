using UnityEngine;
using UnityEngine.EventSystems;

public class InventoryItem : MonoBehaviour, IPointerDownHandler, IBeginDragHandler, IEndDragHandler, IDragHandler {
    
    private RectTransform rectTransform;

    [SerializeField]
    private Canvas canvas;

    private void Awake() {
        rectTransform = transform as RectTransform;
    }

    public void OnBeginDrag(PointerEventData eventData) {
    }

    public void OnDrag(PointerEventData eventData) {
        rectTransform.anchoredPosition += (eventData.delta/canvas.scaleFactor); //increments the object position and makes sure canvas scale doesnt mess up the increment
    }

    public void OnEndDrag(PointerEventData eventData) {
    }

    public void OnPointerDown(PointerEventData eventData) {
        Debug.Log("pointed down");
    }
}
