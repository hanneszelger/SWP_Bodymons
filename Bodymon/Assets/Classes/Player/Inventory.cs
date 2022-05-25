using System;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public bool[] isFull;
    [NonSerialized]
    public List<GameObject> slots = new List<GameObject>();
    private SpriteRenderer[] sr;
    public Items[] items;
    public bool visible;

    // Start is called before the first frame update
    void Start()
    {
        //player = go.GetComponent<Bodymon>();
        sr = gameObject.GetComponentsInChildren<SpriteRenderer>();
        Transform[] childs = gameObject.GetComponentsInChildren<Transform>();

        SaveGame.Load("invItems", this);

        Shop temp = new Shop();
        temp.inventory = this;

        for (int i = 0; i < childs.Length; i++)
        {
            if (childs[i].tag.Equals("slot"))
            {
                //Debug.Log(childs);
                slots.Add(childs[i].gameObject);
            }
        }

        for (int j = 0; j - 1 < items.Length; j++)
        {
            try
            {
                if (this.isFull[j])
                {
                    GameObject goTemp = items[j].prefab;

                    temp.inventory = this;

                    temp.addItem(j, goTemp);
                }
            }
            catch
            {
                Debug.Log("Error");
            }
        }
        SetVisible(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            UseItem(0);
            //if ((float)slots[0].transform.childCount != 0)
            //{
            //    Inventory.Destroy(slots[0].transform.GetChild(0).gameObject);
            //    //foreach (Component c in slots[0].transform.GetChild(0).gameObject.GetComponents(typeof(Component)))
            //    //{
            //    //    Inventory.Destroy(c);
            //    //}
            //}
        }
        //if (Input.GetAxis("Inventory2") == 1)
        //{

        //}
        //if (Input.GetAxis("Inventory3") == 1)
        //{

        //}
        if (Input.GetKeyDown(KeyCode.R))
        {
            ToggleVisible();
        }
    }

    void ToggleVisible()
    {
        SetVisible(!gameObject.GetComponent<SpriteRenderer>().enabled);
    }

    void SetVisible(bool activation)
    {
        gameObject.GetComponent<SpriteRenderer>().enabled = activation;
        sr = gameObject.GetComponentsInChildren<SpriteRenderer>();
        for (int i = 0; i < sr.Length; i++)
        {
            sr[i].enabled = activation;
        }
        visible = activation;
    }

    void UseItem(int i)
    {
        if ((float)slots[i].transform.childCount != 0)
        {
            int alreadyActive = -1;
            Items item = slots[i].transform.GetChild(0).GetComponent<Item>().item;





            alreadyActive = PlayerBodymon.player.Items.FindIndex(f => f == item);
            Debug.Log(alreadyActive);


            Debug.Log("runs");
            //int index = activeItem.ItemBuffs.FindIndex(f => f.Buffstyle == item.ItemBuffs[j].Buffstyle);


            if (alreadyActive == -1)
            {
                PlayerBodymon.player.Items.Add(item);
                Inventory.Destroy(slots[i].transform.GetChild(0).gameObject);
                Debug.Log(item.Name + " wurde verwendet!");
                isFull[i] = false;
                items[i] = null;
            }
            else
            {
                Debug.Log("Das Item ist bereits aktiv: " + item.Name);
            }
        }

    }

    private void OnDestroy()
    {
        SaveGame.Save("invItems", JsonUtility.ToJson(this));
        //Debug.Log(JsonUtility.ToJson(this));
        //Debug.Log(JsonUtility.ToJson(isFull));
    }
}
