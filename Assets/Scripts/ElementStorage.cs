using System;
using System.Collections.Generic;
using UnityEngine;

public class ElementStorage : MonoBehaviour
{
    public List<Element> discoveredElements = new();

    public static Action<Element> OnConnection;

    public event Action<Element> OnDiscover;

    private void Start()
    {
        OnConnection += CheckElement;
    }

    private void CheckElement(Element element)
    {
        foreach (var item in discoveredElements)
        {
            if(item == element) return;
        }

        discoveredElements.Add(element);
        OnDiscover?.Invoke(element);
    }
    

    private void OnDisable()
    {
        OnConnection -= CheckElement;
    }
}
