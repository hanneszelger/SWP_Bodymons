using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using UnityEngine.UI;

public class Stats : MonoBehaviour
{
    Text[] childrenOfUI;

    // Start is called before the first frame update
    void Start()
    {
        try
        {
            StartCoroutine(ReloadText());
        }
        catch 
        {
            
        }
    }

    

    // Update is called once per frame
    void Update()
    {
        
    }

    public IEnumerator ReloadText()
    {
        while (true)
        {
            childrenOfUI = gameObject.GetComponentsInChildren<Text>();

            for (int i = 0; i < childrenOfUI.Length; i++)
            {
                object temp = PlayerBodymon.player.GetType().GetProperty((string)childrenOfUI[i].tag).GetValue(PlayerBodymon.player, null);
                childrenOfUI[i].text = temp.ToString();
            }
            yield return new WaitForSeconds(1);
        }
    }
}

public static class PlayerBodymon
{
    public static Bodymons player = SaveGame.LoadPlayer();
}
