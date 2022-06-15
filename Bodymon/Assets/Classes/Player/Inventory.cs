﻿using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    public bool[] isFull;
    [NonSerialized]
    public List<GameObject> slots = new List<GameObject>();
    [NonSerialized]
    private Image[] sr;
    public Items[] items;
    public static bool visible;

    [NonSerialized]
    public GameObject MuscleStatsGrid;

    // Start is called before the first frame update
    void Start()
    {
        
        //player = go.GetComponent<Bodymon>();
        sr = gameObject.GetComponentsInChildren<Image>();
        Transform[] childs = gameObject.GetComponentsInChildren<Transform>();

        SaveGame.Load("invItems", this);

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

                    LoadItemGameObject(j, goTemp);
                }
            }
            catch
            {
                //Debug.Log("Error");
            }
        }

        if (isFull.Length == 0)
        {
            isFull = new bool[9];
            sr = new Image[9];
            items = new Items[9];
        }
        MuscleStatsGrid = GameObject.FindGameObjectWithTag("MuscleStatGrid");
        SetVisible(false);
    }

    public void LoadItemGameObject(int i, GameObject _item)
    {
        this.isFull[i] = true;


        BoxCollider2D temp = this.slots[i].gameObject.GetComponent<BoxCollider2D>();

        GameObject go = Instantiate(_item, this.slots[i].transform.position, new Quaternion(), this.slots[i].transform) as GameObject;

        RectTransform rend = go.GetComponentInChildren<RectTransform>();

        rend.sizeDelta = new Vector2(temp.size.x - 0.15f, temp.size.y - 0.15f);


        //go.transform.localScale = new Vector3(temp.bounds.size.x / rend.sprite.bounds.size.x,
        //    temp.bounds.size.y / rend.sprite.bounds.size.y, 1);
        //rend = 101;

        //rend.enabled = visible;
        this.items[i] = go.GetComponent<Item>().item;
    }

    // Update is called once per frame
    void Update()
    {
        //if (Input.GetKeyDown(KeyCode.Q))
        //{
        //    UseItem(0);
        //    //if ((float)slots[0].transform.childCount != 0)
        //    //{
        //    //    Inventory.Destroy(slots[0].transform.GetChild(0).gameObject);
        //    //    //foreach (Component c in slots[0].transform.GetChild(0).gameObject.GetComponents(typeof(Component)))
        //    //    //{
        //    //    //    Inventory.Destroy(c);
        //    //    //}
        //    //}
        //}
        //if (Input.GetAxis("Inventory2") == 1)
        //{

        //}
        //if (Input.GetAxis("Inventory3") == 1)
        //{

        //}

        for (int number = 1; number <= 9; number++)
        {
            
                if (Input.GetKeyDown(number.ToString()))
                    UseItem(number - 1);
            
            //catch 
            //{
            //    Debug.Log("Itemslot is empty!");
            //}
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            ToggleVisible();
        }
    }

    void ToggleVisible()
    {
        SetVisible(!gameObject.GetComponent<Image>().enabled);
    }

    void SetVisible(bool activation)
    {
        gameObject.GetComponent<Image>().enabled = activation;
        sr = gameObject.GetComponentsInChildren<Image>();
        for (int i = 0; i < sr.Length; i++)
        {
            sr[i].enabled = activation;
        }
        MuscleStatsGrid.SetActive(activation);
        visible = activation;
    }

    void UseItem(int i)
    {
        if ((float)slots[i].transform.childCount != 0)
        {
            int alreadyActive = -1;
            Items item = slots[i].transform.GetChild(0).GetComponent<Item>().item;

            alreadyActive = PlayerBodymon.player.Items.FindIndex(f => f == item);

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
