using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpItem : MonoBehaviour
{
    private Inventory inventory;
    public GameObject item;

    // Start is called before the first frame update
    void Start()
    {
        inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void buyItem()
    {
        for(int i = 0; i < inventory.slots.Length; i++)
        {
            if (!inventory.isFull[i])
            {
                inventory.isFull[i] = true;
                //creates a copy of an gameobject at the inventoryslot position
                //ToDo: maybe add ,false
                Instantiate(item, inventory.slots[i].transform);
                break;
            }
        }
    }
}
