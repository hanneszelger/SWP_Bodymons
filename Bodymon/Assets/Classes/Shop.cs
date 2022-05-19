using System.Collections;
using System.Collections.Generic;
using UnityEngine.Rendering;
using UnityEngine.Rendering.RendererUtils;
using UnityEngine;

public class Shop : MonoBehaviour
{
    private Inventory inventory;
    private GameObject item;
    private GameObject player;

    public GameObject fire;
    public GameObject arrow;
    List<List<Transform>> rows = new List<List<Transform>>();
    private int currentX = 0;
    private int currentY = 0;
    public float smoothTime = 0.3F;
    private Vector2 velocity = Vector2.zero;


    private float horizontal;
    private float vertical;

    public bool buy;

    // Start is called before the first frame update
    void Start()
    {
        inventory = GameObject.FindGameObjectWithTag("Inventory").GetComponent<Inventory>();
        LoadGrid1();
        player = GameObject.FindGameObjectWithTag("Player");
        player.SetActive(false);
        //player.enabled = false;
    }

    void Leave()
    {
        if (Input.GetAxis("Cancel") == 1)
        {
            player.SetActive(true); 
        }
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
        }
        if (Input.GetButtonDown("Interact"))
        {
            item = rows[currentY][currentX].gameObject;
            buyItem();
        }
        Leave();            
    }

    private void FixedUpdate()
    {
        Vector2 targetPosition = rows[currentY][currentX].position;
        arrow.transform.position = Vector2.SmoothDamp(arrow.transform.position, new Vector2(targetPosition.x, targetPosition.y + 2.5f), ref velocity, smoothTime);
        fire.transform.position = new Vector2(targetPosition.x, targetPosition.y - 0.5f);
    }
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
                rows.Add(new List<Transform>(positions));
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
        }
        return list;
    }

    void buyItem()
    {
        for(int i = 0; i - 1 < inventory.slots.Length; i++)
        {
            if (!inventory.isFull[i])
            {
                inventory.isFull[i] = true;

                BoxCollider2D temp = inventory.slots[i].gameObject.GetComponent<BoxCollider2D>();
                          
                GameObject go = Instantiate(item, inventory.slots[i].transform.position, new Quaternion(), inventory.slots[i].transform) as GameObject;
                
                Renderer rend = go.GetComponentInChildren<SpriteRenderer>();
                go.transform.localScale = new Vector3(temp.bounds.size.x / rend.bounds.size.x - 0.1f,
                    temp.bounds.size.y / rend.bounds.size.y - 0.1f, 1);
                rend.sortingOrder = 101;

                rend.enabled = inventory.visible;

                break;
            }
        }
    }
}

