using UnityEngine;

public class Inventory : MonoBehaviour
{
    public bool[] isFull;
    public GameObject[] slots;
    private SpriteRenderer[] sr;

    private Bodymon player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Bodymon>();
        sr = gameObject.GetComponentsInChildren<SpriteRenderer>();

        isFull = new bool[slots.Length];
        for (int i = 0; i < isFull.Length; i++)
        {
            if (slots[i].gameObject.tag.Equals("EmptyItem"))
            {
                isFull[i] = false;
            }
        }
        gameObject.GetComponent<SpriteRenderer>().enabled = false;
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
        sr = gameObject.GetComponentsInChildren<SpriteRenderer>();
        for (int i = 0; i < sr.Length; i++)
        {
            sr[i].enabled = !sr[i].enabled;
        }
    }

    void UseItem(int i)
    {
        if ((float)slots[i].transform.childCount != 0)
        {
            int alreadyActive = -1;
            Item item = slots[i].transform.GetChild(0).GetComponent<Item>();


            for (int j = 0; j < item.ItemBuffs.Count; j++)
            {
                alreadyActive = player.ActiveItems.FindIndex(f => f.PrefabName == item.PrefabName);
                Debug.Log(alreadyActive);
                if (alreadyActive == -1) break;
                
                
                Debug.Log("runs");
                //int index = activeItem.ItemBuffs.FindIndex(f => f.Buffstyle == item.ItemBuffs[j].Buffstyle);
            }

            if (alreadyActive == -1)
            {
                player.ActiveItems.Add(item);
                Inventory.Destroy(slots[i].transform.GetChild(0).gameObject);
                Debug.Log(item.Name + " wurde verwendet!");
                isFull[i] = false;
            }
            else
            {
                Debug.Log("Das Item ist bereits aktiv: " + item.Name);
            }
        }

    }
}
