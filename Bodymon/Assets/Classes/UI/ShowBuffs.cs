using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowBuffs : MonoBehaviour
{
    public bool buffsVisible;
    private List<Buffstyle> list = new List<Buffstyle>();

    // Start is called before the first frame update
    private void Start()
    {
        //iterates through all items the player has active and adds a GameObject with the BuffIcon as a child
        foreach (Items item in PlayerBodymon.player.Items)
        {
            foreach (ItemBuff ibuff in item.ItemBuffs)
            {
                if (!list.Contains(ibuff.TypeOfBuff))
                {
                    GameObject goTemp = Resources.Load<GameObject>("Prefabs/BuffIconTemplate");
                    Image goImage = goTemp.GetComponent<Image>();
                    Debug.Log(ibuff.IconPath);
                    goImage.sprite = Resources.Load<Sprite>(ibuff.IconPath);
                    GameObject displayedObject = GameObject.Instantiate(goTemp, gameObject.transform);
                    displayedObject.name = ibuff.TypeOfBuff.ToString();
                    list.Add(ibuff.TypeOfBuff);
                }
            }
        }
        ToggleBuffVisible(buffsVisible);
    }

    // Update is called once per frame
    private void Update()
    {
        //checks if a new buff is activated
        Start();

        if (Input.GetKeyDown(KeyCode.I))
        {
            ToggleBuffVisible();
        }
    }

    private void ToggleBuffVisible()
    {
        ToggleBuffVisible(!buffsVisible);
    }

    private void ToggleBuffVisible(bool visible)
    {
        Transform[] temp = gameObject.GetComponentsInChildren<Transform>(true);
        for (int i = 0; i < temp.Length; i++)
        {
            if (i != 0) temp[i].gameObject.SetActive(visible);
        }
        buffsVisible = visible;
    }
}