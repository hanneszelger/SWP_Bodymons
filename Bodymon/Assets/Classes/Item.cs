using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    // Start is called before the first frame update
    public Items Items;

    private string _prefabName;

    private string _Name;
    private Sprite _Icon;
    private int _Cost;
    //private ItemType _ItemType;

    void Start()
    {
       
        //_ItemType = Items.ItemType;
        Debug.Log(_Name);

        GetComponent<SpriteRenderer>().sprite = Items.Icon;
        gameObject.name = Items.prefabName;
        _Name = Items.name;
        _prefabName = Items.prefabName;
        _Cost = Items.Cost;

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
