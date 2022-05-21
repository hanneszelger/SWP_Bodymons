using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Stats : MonoBehaviour
{
    Text[] childrenOfUI;

    // Start is called before the first frame update
    void Start()
    {
        childrenOfUI = gameObject.GetComponentsInChildren<Text>();

        for (int i = 0; i < childrenOfUI.Length; i++)
        {
            object temp = PlayerBodymon.player.GetType().GetProperty((string)childrenOfUI[i].tag).GetValue(PlayerBodymon.player, null);
            childrenOfUI[i].text = temp.ToString();
        }
    }

    

    // Update is called once per frame
    void Update()
    {
        
    }
}

public static class PlayerBodymon
{
    public static Bodymons player = Resources.Load<Bodymons>("Player");
}
