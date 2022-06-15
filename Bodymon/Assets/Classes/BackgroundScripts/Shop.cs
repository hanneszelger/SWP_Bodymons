using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.RendererUtils;
using UnityEngine.SceneManagement;

public class Shop : MonoBehaviour
{
    [HideInInspector]
    private GameObject item;
    private GameObject player;

    public GameObject fire;
    public GameObject arrow;
    List<List<RectTransform>> rows = new List<List<RectTransform>>();
    private int currentX = 0;
    private int currentY = 0;
    public float smoothTime = 0.3F;
    private Vector2 velocity = Vector2.zero;


    private float horizontal;
    private float vertical;

    public UnityEngine.UI.Text txt_itemCost, txt_message;
    public UnityEngine.UI.Image panel;

    // Start is called before the first frame update
    void Start()
    {
        LoadGrid1();
        txt_message.CrossFadeAlpha(0, 0, false);
        panel.CrossFadeAlpha(0, 0, false);
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
        // Checks the currently selected item (Movement controlled with arrows or WASD)
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

            switch (SaveGame.AddItemToInventoryBuy(item.GetComponent<Item>().item))
            {
                case -2:
                    txt_message.text = "Seems like you are missing some coins!";
                    break;
                case -1:
                    txt_message.text = "Master, you already have this item!";
                    break;
                case 0:
                    txt_message.text = "You have no place to store this item!";
                    break;
                case 1:
                    txt_message.text = "Bought! GET BIG!";
                    GetComponent<AudioSource>().Play();
                    break;
            }
            StartCoroutine(FadeTextInAndOut(0.5f, 3));
        }

        txt_itemCost.text = rows[currentY][currentX].gameObject.GetComponent<Item>().item.Cost.ToString();
        txt_itemCost.color = PlayerBodymon.player.Coins >= Int32.Parse(txt_itemCost.text) ? Color.green : Color.red;

        //Checks for ESC and then changes scene
        Leave();
    }

    IEnumerator FadeTextInAndOut(float fadeDuration, float activeDuration)
    {
        txt_message.CrossFadeAlpha(1, fadeDuration, false);
        panel.CrossFadeAlpha(1, fadeDuration, false);
        yield return new WaitForSeconds(activeDuration);
        txt_message.CrossFadeAlpha(0, fadeDuration, false);
        panel.CrossFadeAlpha(0, fadeDuration, false);
    }

    private void FixedUpdate()
    {
        //Moves the Arrow and fire to the currently selected item's position
        Vector2 targetPosition = rows[currentY][currentX].position;
        arrow.transform.position = Vector2.SmoothDamp(arrow.transform.position, new Vector2(targetPosition.x, targetPosition.y + 2.5f), ref velocity, smoothTime);
        fire.transform.position = new Vector2(targetPosition.x, targetPosition.y);
    }

    void LoadGrid1()
    {
        float previousY = 0;

        List<RectTransform> positions = new List<RectTransform>();

        //iterates through the children of the gameobject and if the y value differs, a new row is created
        //NOTE: Mind the hierachy!
        for (int i = 0; i < gameObject.transform.childCount; i++)
        {
            RectTransform child = gameObject.transform.GetChild(i).GetComponent<RectTransform>();
            positions.Add(child);
            previousY = child.position.y;
            if (i + 1 == gameObject.transform.childCount || (child.position.y != gameObject.transform.GetChild(i + 1).position.y))
            {
                rows.Add(new List<RectTransform>(positions));
                positions.Clear();
            }
        }
    }

    private void OnDestroy()
    {
        SaveGame.SavePlayer();
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