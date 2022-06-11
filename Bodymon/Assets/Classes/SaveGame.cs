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

    public static void AddItemToInventory(Items SOitem)
    {
        Inventory temp = new Inventory();
        Load("invItems", temp);
        bool bought = false;
        for (int i = 0; i < temp.isFull.Length; i++)
        {
            if (!temp.isFull[i])
            {
                temp.items[i] = SOitem;
                temp.isFull[i] = true;

                Debug.Log("Bought: " + SOitem.Name);
                bought = true;
                break;
            }
        }

        if (!bought)
        {
            //Debug.Log("Player's inventory is full!");
            //throw new System.Exception("Player's inventory is full!");
        }

        Save("invItems", JsonUtility.ToJson(temp));
    }

    public static void AddItemToInventoryBuy(Items SOitem)
    {
        if (PlayerBodymon.player.Coins >= SOitem.Cost)
        {
            AddItemToInventory(SOitem);
        }
        else
        {
            Debug.Log("Player has not enough Coins to buy this Item(" + (SOitem.Cost - PlayerBodymon.player.Coins) + " Coins missing");
            //throw new System.Exception("Player has not enough Coins to buy this Item (" + (SOitem.Cost - PlayerBodymon.player.Coins) + " Coins missing");
        }
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