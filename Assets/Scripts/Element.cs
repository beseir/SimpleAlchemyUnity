using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "Element", menuName = "New Element", order = 1)]
[System.Serializable]
public class Element : ScriptableObject
{
    public string Name;
    public int ID;
    public Sprite Icon;
    public List<ElementConnection> connections = new();

    
}
