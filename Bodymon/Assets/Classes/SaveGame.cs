using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public static class SaveGame 
{
    public static void Save(string preferenceName, string data)
    {
        PlayerPrefs.SetString(preferenceName, data);
        PlayerPrefs.Save();
        //https://answers.unity.com/questions/1325056/how-to-use-playerprefs-2.html
    }

    public static void SavePlayer(string preferenceName)
    {
        Save(preferenceName, JsonUtility.ToJson(PlayerBodymon.player));
    }



    public static void Load(string preferenceName, object output)
    {
        JsonUtility.FromJsonOverwrite(PlayerPrefs.GetString(preferenceName), output);
    }

    public static void LoadPlayer(string preferenceName)
    {
        JsonUtility.FromJsonOverwrite(PlayerPrefs.GetString(preferenceName), PlayerBodymon.player);
    }

    //public static void loadItems()
    //{
    //    Resources.Load<GameObject>("Items/BadeSalz");
    //    SaveGame.Load("inventory", );
    //}

    //public static void SaveInventoryItems()
    //{
    //    SaveGame.Save("inventory", );
    //}
}

