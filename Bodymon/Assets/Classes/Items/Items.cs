using System.Collections.Generic;
using UnityEngine;

//ScriptableObject -> makes loading Data way easier
[CreateAssetMenu(menuName = "ScriptableObject/Items", fileName = "Item", order = 0)]
public class Items : ScriptableObject
{
    public string PrefabName;
    public GameObject prefab;
    public string Name;
    public Sprite Icon;
    public int Cost;
    public ItemType ItemType;
    public List<ItemBuff> ItemBuffs;
}

public enum ItemType
{
    Supplement,
    Gear,
    AnabolicSteroids
}

[System.Serializable]
public class ItemBuff
{
    public Buffstyle TypeOfBuff;
    //returns the IconPath according to the TypeOfBuff
    public string IconPath
    {
        get { return ("icons/" + TypeOfBuff.ToString()); }
        set { IconPath = value; }
    }

    public int value;
    public int duration;

}
[SerializeField]
public enum Buffstyle
{
    Strength,
    Endurance,
    Synthesis,
    Anabol
}

