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
    //private ItemType _ItemType;

    void Start()
    {
        PrefabName = item.PrefabName;
        gameObject.name = item.PrefabName;
        Name = item.Name;
        Icon = GetComponent<SpriteRenderer>().sprite = item.Icon;
        Cost = item.Cost;
        ItemType = item.ItemType;
        ItemBuffs = item.ItemBuffs;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
