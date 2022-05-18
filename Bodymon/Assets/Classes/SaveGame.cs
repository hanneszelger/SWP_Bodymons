using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class SaveGame : MonoBehaviour
{
    public GameObject playerObject;
    Bodymon player;


    // Start is called before the first frame update
    void Start()
    {
        player = playerObject.GetComponent<Bodymon>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void Save(string preferenceName)
    {
        PlayerPrefs.SetString(preferenceName, JsonUtility.ToJson(player));
        PlayerPrefs.Save();
        //https://answers.unity.com/questions/1325056/how-to-use-playerprefs-2.html
    }

    void Load(string preferenceName)
    {
        JsonUtility.FromJsonOverwrite(PlayerPrefs.GetString(preferenceName), player);
    }
}
