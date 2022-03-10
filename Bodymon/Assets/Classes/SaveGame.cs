using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class SaveGame : MonoBehaviour
{
    public GameObject playerObject;
    Bodymons player;


    // Start is called before the first frame update
    void Start()
    {
        player = playerObject.GetComponent<Bodymons>();
    }

    // Update is called once per frame
    void Update()
    {
    }

    void Save()
    {

        PlayerPrefs.SetString("player_bodymon", JsonUtility.ToJson(player));
        PlayerPrefs.Save();
        //https://answers.unity.com/questions/1325056/how-to-use-playerprefs-2.html
    }

    void Load()
    {
        JsonUtility.FromJsonOverwrite(PlayerPrefs.GetString("player_bodymon"), player);
    }
}
