using UnityEngine;

public class SpawnElementButton : MonoBehaviour
{
    public Element element;
    private GameObject playground;
    private GameObject listUI;
    [SerializeField] private GameObject elementPrototype;
    private void Awake()
    {
        playground = GameObject.FindGameObjectWithTag("Playground"); 
        listUI = GameObject.FindGameObjectWithTag("ListUI");
    }
    public void SpawnElement()
    {
        var newElement = Instantiate(elementPrototype, Vector3.zero, Quaternion.identity);
        newElement.transform.SetParent(playground.transform);
        newElement.transform.localPosition = transform.localPosition;
        newElement.transform.localScale = Vector3.one;

        ElementContainer container = newElement.GetComponent<ElementContainer>();
        container.element = element;
        container.InitElement();

        listUI = GameObject.FindGameObjectWithTag("ListUI");
        listUI.SetActive(false);
    }
}
