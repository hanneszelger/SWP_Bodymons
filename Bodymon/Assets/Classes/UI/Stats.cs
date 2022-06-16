using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Stats : MonoBehaviour
{
    private Text[] childrenOfUI;

    // Start is called before the first frame update
    private void Start()
    {
        try
        {
            StartCoroutine(ReloadText());
        }
        catch
        {
        }
    }

    /// <summary>
    /// Reloads playerstats once every second
    /// </summary>
    /// <returns></returns>
    public IEnumerator ReloadText()
    {
        // while true -> so it runs all the time
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
    //Already leveled user with items
    public static Bodymons player = Resources.Load<Bodymons>("Player");

    //if object alreay exists in playerprefs and you want to test other scenes
    //public static Bodymons player = SaveGame.LoadPlayer();
}