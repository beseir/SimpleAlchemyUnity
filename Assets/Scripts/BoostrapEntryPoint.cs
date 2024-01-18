using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoostrapEntryPoint : MonoBehaviour
{
    [SerializeField] private ElementStorage elementStorage;
    [SerializeField] private StorageUI storageUI;
    [SerializeField] private SaveManager saveManager;
    [SerializeField] private ProgressBar progBar;

    private void Awake()
    {
        elementStorage.Init();
        storageUI.Init();
        progBar.Init();
        saveManager.Init();
        saveManager.Load();
    }
}
