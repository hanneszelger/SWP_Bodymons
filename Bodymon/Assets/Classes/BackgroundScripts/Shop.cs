﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine.Rendering;
using UnityEngine.Rendering.RendererUtils;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Threading.Tasks;

public class Shop : MonoBehaviour
{
    [HideInInspector]
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
        LoadGrid1();
    }

    void Leave()
    {
        if (Input.GetButtonDown("Cancel"))
        {
            SavedPositionManager.lastScene = 1;
            SceneManager.LoadScene(0, LoadSceneMode.Single);
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
            SaveGame.AddItemToInventoryBuy(item.GetComponent<Item>().item);
            GetComponent<AudioSource>().Play();
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
}