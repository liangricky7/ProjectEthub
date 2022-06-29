using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class InventoryItem : MonoBehaviour, IPointerDownHandler, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    public void OnBeginDrag(PointerEventData eventData) {
        Debug.Log("onBeginDrag");
    }

    public void OnDrag(PointerEventData eventData) {
        Debug.Log("onDrag");

    }

    public void OnEndDrag(PointerEventData eventData) {
        Debug.Log("onEndDrag");

    }

    public void OnPointerDown(PointerEventData eventData) {
        Debug.Log("onPointerDown");
    }
}
