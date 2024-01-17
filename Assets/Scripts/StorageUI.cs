using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StorageUI : MonoBehaviour
{
    [SerializeField] private SpawnElementButton buttonPrototype;
    [SerializeField] private GameObject list;
    private ElementStorage storage;
    private void Awake()
    {
        storage = FindObjectOfType<ElementStorage>();
    }

    private void Start()
    {
        storage.OnDiscover += CreateButton;
    }

    private void CreateButton(Element element)
    {
        print("ad");
        var button = Instantiate(buttonPrototype.gameObject, transform.position, Quaternion.identity).GetComponent<SpawnElementButton>();
        button.transform.SetParent(list.transform);
        button.transform.localScale = Vector3.one;
        button.element = element;
        button.GetComponent<Image>().sprite = element.Icon;
       
    }
    private void OnDisable()
    {
        storage.OnDiscover -= CreateButton;

    }
}
