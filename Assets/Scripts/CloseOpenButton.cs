using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseOpenButton : MonoBehaviour
{
    [SerializeField]
    private GameObject go;



public void Use()
    {
        go.SetActive(!go.activeInHierarchy);
    }
}
