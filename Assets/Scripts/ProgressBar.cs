using UnityEngine;
using UnityEngine.UI;

public class ProgressBar : MonoBehaviour
{
    private ElementStorage storage;
    public int currentCount, maxAmount;

    private Image image;

    private void Awake()
    {
        image = GetComponent<Image>();
        storage = FindObjectOfType<ElementStorage>();
    }
    private void Start()
    {
        storage.OnDiscover += IncrementProgress;

    }

    private void IncrementProgress(Element element)
    {
        currentCount++;
        image.fillAmount = (float)currentCount / maxAmount;
    }
    private void OnDisable()
    {
        storage.OnDiscover -= IncrementProgress;
    }
}
