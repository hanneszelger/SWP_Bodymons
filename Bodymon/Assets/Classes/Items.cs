using System.Collections;
using System.Collections.Generic;
using UnityEngine;




[CreateAssetMenu (menuName = "Items")]
public class Items : ScriptableObject
{

    public string prefabName;
    public string Name;
    public Sprite Icon;
    public int Cost;
    public ItemType ItemType;
}

public enum ItemType
{
    Supplement,
    Gear,
    AnabolicSteroids
}
