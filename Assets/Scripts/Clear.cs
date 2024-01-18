using UnityEngine;
using UnityEngine.EventSystems;

public class Clear : MonoBehaviour, IDropHandler
{
    private GameObject pg;
    private void Awake()
    {
        pg = GameObject.FindGameObjectWithTag("Playground");
    }

    public void ClearAll()
    {
        foreach (var item in FindObjectsOfType<ElementController>())
        {
            item.gameObject.SetActive(false);
        }
    }

    public void OnDrop(PointerEventData eventData)
    {
        eventData.pointerClick.SetActive(false);
    }
}
