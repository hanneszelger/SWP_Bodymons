using System;
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
    private void Start()
    {
        //player = go.GetComponent<Bodymon>();
        sr = gameObject.GetComponentsInChildren<Image>();
        Transform[] childs = gameObject.GetComponentsInChildren<Transform>();

        SaveGame.Load("invItems", this);

        //adds GameObjects slots from the loaded inventory
        for (int i = 0; i < childs.Length; i++)
        {
            if (childs[i].tag.Equals("slot"))
            {
                slots.Add(childs[i].gameObject);
            }
        }

        //iterates through the items from the loaded inventory
        for (int j = 0; j - 1 < items.Length; j++)
        {
            try
            {
                if (this.isFull[j])
                {
                    //creates temp GameObject with the defined prefab
                    GameObject goTemp = items[j].prefab;

                    LoadItemGameObject(j, goTemp);
                }
            }
            catch
            {
            }
        }

        //if the isFUll array is empty -> create empty inv.
        if (isFull.Length == 0)
        {
            isFull = new bool[9];
            sr = new Image[9];
            items = new Items[9];
        }
        MuscleStatsGrid = GameObject.FindGameObjectWithTag("MuscleStatGrid");
        SetVisible(false);
    }

    /// <summary>
    /// Loads items to the Inventory UI
    /// </summary>
    /// <param name="i"></param>
    /// <param name="_item"></param>
    public void LoadItemGameObject(int i, GameObject _item)
    {
        this.isFull[i] = true;

        BoxCollider2D temp = this.slots[i].gameObject.GetComponent<BoxCollider2D>();

        //Clones the _item gameobject to the needed position
        GameObject go = Instantiate(_item, this.slots[i].transform.position, new Quaternion(), this.slots[i].transform) as GameObject;

        RectTransform rend = go.GetComponentInChildren<RectTransform>();

        //scales the image to the collider's size
        rend.sizeDelta = new Vector2(temp.size.x - 0.15f, temp.size.y - 0.15f);

        this.items[i] = go.GetComponent<Item>().item;
    }

    // Update is called once per frame
    private void Update()
    {
        for (int number = 1; number <= 9; number++)
        {
            if (Input.GetKeyDown(number.ToString()))
                UseItem(number - 1);
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            ToggleVisible();
        }
    }

    private void ToggleVisible()
    {
        SetVisible(!gameObject.GetComponent<Image>().enabled);
    }

    /// <summary>
    /// Sets visibility of all Images accrodingly
    /// </summary>
    /// <param name="activation"></param>
    private void SetVisible(bool activation)
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

    private void UseItem(int i)
    {
        if ((float)slots[i].transform.childCount != 0)
        {
            int alreadyActive = -1;
            Items item = slots[i].transform.GetChild(0).GetComponent<Item>().item;

            // -1 if item is already active -> not really really needed
            alreadyActive = PlayerBodymon.player.Items.FindIndex(f => f == item);

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
    }
}