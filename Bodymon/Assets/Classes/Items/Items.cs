using System.Collections.Generic;
using UnityEngine;


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
    public Buffstyle Buffstyle;
    public int value;
    public int duration;
    //public ItemBuff(Buffstyle _Buffstyle, int _value)
    //{
    //    value = _value;
    //}
}
[SerializeField]
public enum Buffstyle
{
    Strenght,
    Endurance,
    Synthesis
}

