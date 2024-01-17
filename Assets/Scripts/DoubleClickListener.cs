using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class DoubleClickListener: MonoBehaviour, IPointerClickHandler
{
    private float doubleClickTimeLimit = 0.25f;
    private int clicks = 0;
    private GameObject canvas;
    private Vector3 spawnOffset => new Vector3(40, 40, 0);

    private void Awake()
    {
        canvas = GameObject.FindGameObjectWithTag("Playground");
    }
    public void OnPointerClick(PointerEventData eventData)
    {
        clicks++;
        StartCoroutine(ClickListener());
    }

    private IEnumerator ClickListener()
    {
        yield return new WaitForSeconds(doubleClickTimeLimit);
        if (clicks >= 2) CloneElement();
        clicks = 0;
    }
    private void CloneElement()
    {
        var clone = Instantiate(gameObject, transform.position + spawnOffset, Quaternion.identity);
        clone.transform.SetParent(canvas.transform);
        clone.transform.localScale = Vector3.one;
    }
  
}