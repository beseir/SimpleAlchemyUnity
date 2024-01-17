using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class ElementContainer : MonoBehaviour
{
    public Element element;

    [SerializeField] private TextMeshProUGUI nameText;

    private Image image;
    private ElementController controller;
    private GameObject canvas;

    private void Awake()
    {
        canvas = GameObject.FindGameObjectWithTag("Playground");
        image = GetComponent<Image>();
        controller = GetComponent<ElementController>();
        CurrentElement = element;
    }
    private void Start()
    {
        controller.OnElementDrop += CheckDrop;
        InitElement();
    }
    private void OnDisable()
    {
        controller.OnElementDrop -= CheckDrop;
    }

    private void CheckDrop(GameObject hitObject)
    {
        if(hitObject.TryGetComponent<ElementContainer>(out ElementContainer container))
        {
            if(TryFindConnection(container, out Element result))
            {
                if (result == null) return;
                ConnectElements(hitObject, result);
          
            }
        }
    }

    private void ConnectElements(GameObject hitObject, Element result)
    {
        var newElement = Instantiate(gameObject, transform.position, Quaternion.identity);
        newElement.GetComponent<ElementContainer>().CurrentElement = result;
        newElement.transform.SetParent(canvas.transform);
        newElement.transform.localScale = Vector3.one;

        ElementStorage.OnConnection?.Invoke(result);

        hitObject.SetActive(false);
        gameObject.SetActive(false);

    }
    private bool TryFindConnection(ElementContainer connection, out Element result)
    {
        foreach (var item in element.connections)
        {
            if (item.connectionWith == connection.element) 
            {
                result = item.result;
                return true;
            } 
        }
        result = null;
        return false;
    }
    public Element CurrentElement
    {
        get => element;
        set
        {
            element = value;
          
        }
    }

    public void InitElement()
    {
        image.sprite = element.Icon;
        nameText.text = element.Name;
    }
}
