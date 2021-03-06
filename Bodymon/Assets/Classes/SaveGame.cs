using System;
using UnityEngine;

public static class SaveGame
{
    public static void Save(string preferenceName, string data)
    {
        PlayerPrefs.SetString(preferenceName, data);
        PlayerPrefs.Save();

        //https://answers.unity.com/questions/1325056/how-to-use-playerprefs-2.html
    }

    /// <summary>
    /// Saves PlayerBodymon.player in PlaerPrefs as 'bodymonPlayer'
    /// </summary>
    public static void SavePlayer()
    {
        Save("bodymonPlayer", JsonUtility.ToJson(PlayerBodymon.player));
    }

    public static void Load(string preferenceName, object output)
    {
        JsonUtility.FromJsonOverwrite(PlayerPrefs.GetString(preferenceName), output);
    }

    /// <summary>
    /// Loads Player
    /// </summary>
    /// <returns>Bodymons 'bodymonPlayer' from the PlayerPrefs</returns>
    public static Bodymons LoadPlayer()
    {
        Bodymons tempBodymon = ScriptableObject.CreateInstance<Bodymons>();
        JsonUtility.FromJsonOverwrite(PlayerPrefs.GetString("bodymonPlayer"), tempBodymon);
        return tempBodymon;
    }

    /// <summary>
    /// Adds Item to Inventory
    /// </summary>
    /// <param name="SOitem"></param>
    /// <returns>-1 = Player already has this item, 0 = Inventory full, 1 = Bought</returns>
    /// <exception cref="System.Exception"></exception>
    public static float AddItemToInventory(Items SOitem)
    {
        Inventory temp = new Inventory();
        Load("invItems", temp);
        float bought = 0;

        if (!PlayerBodymon.player.Items.Contains(SOitem) && Array.IndexOf(temp.items, SOitem) == -1)
        {
            for (int i = 0; i < temp.isFull.Length; i++)
            {
                if (!temp.isFull[i])
                {
                    temp.items[i] = SOitem;
                    temp.isFull[i] = true;

                    Debug.Log("Bought: " + SOitem.Name);
                    bought = 1;
                    break;
                }
            }
            if (bought == 0)
            {
                Debug.Log("Player's inventory is full!");
            }
        }
        else
        {
            Debug.Log("This item is already active or in your inventory!");
            bought = -1;
        }

        Save("invItems", JsonUtility.ToJson(temp));
        return bought;
    }

    /// <summary>
    /// Adds Item to Inventory and reduces the amount of coins the player has for it's cost
    /// </summary>
    /// <param name="SOitem"></param>
    /// <returns>-2 = Player has not enough Coins, -1 = Player already has this item, 0 = Inventory full, 1 = Bought</returns>
    public static float AddItemToInventoryBuy(Items SOitem)
    {
        if (PlayerBodymon.player.Coins >= SOitem.Cost)
        {
            PlayerBodymon.player.Coins -= SOitem.Cost;
            return AddItemToInventory(SOitem);
        }
        else
        {
            Debug.Log("Player has not enough Coins to buy this Item(" + (SOitem.Cost - PlayerBodymon.player.Coins) + " Coins missing");
            return -2;
        }
    }
}