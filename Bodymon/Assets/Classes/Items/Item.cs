using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Item : MonoBehaviour
{
    // Start is called before the first frame update
    public Items item;

    public string PrefabName;
    public string Name;
    public Sprite Icon;
    public int Cost;
    public ItemType ItemType;
    public List<ItemBuff> ItemBuffs;
    public GameObject Prefab;
    //private ItemType _ItemType;

    //assigns values, so you are able to get it of the gameObject
    private void Start()
    {
        PrefabName = item.PrefabName;
        gameObject.name = item.PrefabName;
        Name = item.Name;
        Cost = item.Cost;
        ItemType = item.ItemType;
        ItemBuffs = item.ItemBuffs;
        Prefab = item.prefab;
    }

    // Update is called once per frame
    private void Update()
    {
    }
}