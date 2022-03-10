using System.Collections;
using System.Collections.Generic;
using UnityEngine.Rendering;
using UnityEngine.Rendering.RendererUtils;
using UnityEngine.Rendering.PostProcessing;
using UnityEngine;

public class Shop : MonoBehaviour
{
    private Inventory inventory;
    public GameObject item;

    public GameObject fire;
    public GameObject arrow;
    List<List<Transform>> rows = new List<List<Transform>>();
    private int currentX = 0;
    private int currentY = 0;
    public float smoothTime = 0.3F;
    private Vector2 velocity = Vector2.zero;


    private float horizontal;
    private float vertical;

    // Start is called before the first frame update
    void Start()
    {
        inventory = GameObject.FindGameObjectWithTag("Inventory").GetComponent<Inventory>();
        LoadGrid1();

        for (int y = 0; y < rows.Count; y++)
        {
            for (int i = 0; i < rows[y].Count; i++)
            {
                Debug.Log(rows[y][i]);
            }
        }
        Debug.Log(rows[0].Count);
        //GetAllChilds(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.anyKeyDown)
        {
            horizontal = Input.GetAxisRaw("Horizontal");
            vertical = Input.GetAxisRaw("Vertical");

            if (currentY + (int)vertical < 0) currentY = rows.Count - 1;
            else if (currentY + 1 + (int)vertical > rows.Count) currentY = 0;
            else currentY += (int)vertical;

            if (currentX + (int)horizontal < 0) currentX = rows[currentY].Count - 1;
            else if (currentX + 1 + (int)horizontal > rows[currentY].Count) currentX = 0;
            else currentX += (int)horizontal;

            
            Debug.Log("[" + currentY + "][" + currentX + "];" + rows[currentY][currentX]);
        }
    }

    private void FixedUpdate()
    {
        Bloom b = null;
        Vector2 targetPosition = rows[currentY][currentX].position;
        arrow.transform.position = Vector2.SmoothDamp(arrow.transform.position, new Vector2(targetPosition.x, targetPosition.y + 2.5f), ref velocity, smoothTime);
        fire.transform.position = new Vector2(targetPosition.x, targetPosition.y - 0.5f);
       
        Debug.Log(currentX);

        //child.GetComponent<PostProcessVolume>();
    }

    //void LoadGrid()
    //{
    //    float previousY = 0;

    //    List<Vector2> positions = new List<Vector2>();
    //    Transform[] items = gameObject.GetComponentsInChildren<Transform>();
    //    for (int i = 1; i < items.Length; i++)
    //    {
    //        positions.Add(new Vector2(items[i].position.x, items[i].position.y + 2.5f));
    //        previousY = items[i].position.y;
    //        if (i + 1 == items.Length || (items[i].position.y != items[i+1].position.y))
    //        {
    //            Debug.Log(positions.Count);
    //            rows.Add(new List<Vector2>(positions));
    //            Debug.Log("Added");
    //            positions.Clear();
    //        }
    //        //Debug.Log(new Vector2(items[i].position.x, items[i].position.y) + ";" + rows.Count + items);
    //    }
    //}
    void LoadGrid1()
    {
        float previousY = 0;

        List<Transform> positions = new List<Transform>();
        
        for (int i = 0; i < gameObject.transform.childCount; i++)
        {
            Transform child = gameObject.transform.GetChild(i);
            //positions.Add(new Vector2(child.position.x, child.position.y + 2.5f));
            positions.Add(child);
            previousY = child.position.y;
            if (i + 1 == gameObject.transform.childCount || (child.position.y != gameObject.transform.GetChild(i+ 1).position.y))
            {
                Debug.Log(positions.Count);
                rows.Add(new List<Transform>(positions));
                Debug.Log("Added");
                positions.Clear();
            }
            
            //Debug.Log(new Vector2(items[i].position.x, items[i].position.y) + ";" + rows.Count + items);
        }
    }

    private List<GameObject> GetAllChilds(GameObject Go)
    {
        List<GameObject> list = new List<GameObject>();
        for (int i = 0; i < Go.transform.childCount; i++)
        {
            Vector2 pos = Go.transform.GetChild(i).position;
            Debug.Log(Go.transform.GetChild(i).gameObject.name +":"+Go.transform.GetChild(i).gameObject.transform.position);
        }
        return list;
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

