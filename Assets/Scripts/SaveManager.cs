using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveManager : MonoBehaviour
{
    private ElementStorage storage;
    [SerializeField] private List<string> names = new();
    [SerializeField] private List<Element> allElements = new();
    public void Init()
    {
        storage = FindObjectOfType<ElementStorage>();
  
    }

    private void OnDisable()
    {
        Save();
    }

    private void OnApplicationQuit()
    {
        Save();
    }
    private void OnApplicationPause(bool pause)
    {
        Save();
    }
    public void Load()
    {
        foreach (var item in allElements)
        {
            if(PlayerPrefs.GetInt(item.name) == 1)
            {
                storage.CheckElement(item);
    
               
            }
        }
    }

    private void Save()
    {
        foreach (var item in storage.discoveredElements)
        {
            PlayerPrefs.SetInt(item.name, 1);
        }
    }
}
