using UnityEngine.UI;
using UnityEngine;
using UnityEngine.EventSystems;
using System;

public class ElementController : MonoBehaviour, IBeginDragHandler, IDragHandler, IDropHandler, IEndDragHandler
{

    private Image image;

    public Action<GameObject> OnElementDrop;

    private void Awake()
    {
        image = GetComponent<Image>();
    }
    public void OnBeginDrag(PointerEventData eventData)
    {
        image.raycastTarget = false;
        image.gameObject.transform.SetAsLastSibling();
    }

    public void OnDrag(PointerEventData eventData)
    {
       transform.position = eventData.position;
    }

    public void OnDrop(PointerEventData eventData)
    {
        OnElementDrop?.Invoke(eventData.pointerDrag.gameObject);
      
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        image.raycastTarget = true;
    }
}
