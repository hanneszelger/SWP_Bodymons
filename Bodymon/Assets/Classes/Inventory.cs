using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public bool[] isFull;
    public GameObject[] slots;
    private SpriteRenderer[] sr;

    private Bodymons player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Bodymons>();
        sr = gameObject.GetComponentsInChildren<SpriteRenderer>();
        
        isFull = new bool[slots.Length];
        for (int i = 0; i < isFull.Length; i++)
        {
            if (slots[i].gameObject.tag.Equals("EmptyItem"))
            {
                isFull[i] = false;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            if ((float)slots[0].transform.childCount != 0)
            {
                Inventory.Destroy(slots[0].transform.GetChild(0).gameObject);
                //foreach (Component c in slots[0].transform.GetChild(0).gameObject.GetComponents(typeof(Component)))
                //{
                //    Inventory.Destroy(c);
                //}
            }
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
        sr = gameObject.GetComponentsInChildren<SpriteRenderer>();
        for (int i = 0; i < sr.Length; i++)
        {
            sr[i].enabled = !sr[i].enabled;
        }
    }

    void UseItem(int i)
    {
        if ((float)slots[i].transform.childCount != i)
        {
            player.Pb.Anabol += 10;

            Inventory.Destroy(slots[i].transform.GetChild(0).gameObject);
        }
           
    }
}
