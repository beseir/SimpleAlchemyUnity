using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class StorageUI : MonoBehaviour
{
    [SerializeField] private SpawnElementButton buttonPrototype;
    [SerializeField] private GameObject list;
    private ElementStorage storage;
    public void Init()
    {
        storage = FindObjectOfType<ElementStorage>();
        storage.OnDiscover += CreateButton;
    }

  

    private void CreateButton(Element element)
    {
        print("created");
        var button = Instantiate(buttonPrototype.gameObject, transform.position, Quaternion.identity).GetComponent<SpawnElementButton>();
        button.transform.SetParent(list.transform);
        button.transform.localScale = Vector3.one;
        button.element = element;
        button.GetComponent<Image>().sprite = element.Icon;
        button.GetComponentInChildren<TextMeshProUGUI>().text = element.Name;
       
    }
    private void OnDisable()
    {
        storage.OnDiscover -= CreateButton;

    }
}
