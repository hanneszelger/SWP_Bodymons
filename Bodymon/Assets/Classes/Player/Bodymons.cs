using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
[CreateAssetMenu(menuName = "ScriptableObject/Bodymons", fileName = "Bodymon", order = 0)]
public class Bodymons : ScriptableObject
{

    private int defaultHp = 100;
    private string defaultName = "Mwenye Munyaradzi";
    private MuscleSet defaultMuscleset = new MuscleSet();
    private int defaultPosingSkill = 1;
    
    [SerializeField]
    private int hp;
    [SerializeField]
    private new string name;
    [SerializeField]
    private bool owned;
    [SerializeField]
    private MuscleSet muscles;
    [SerializeField]
    private List<Item> activeItems;
    [SerializeField]
    private List<Items> item;
    [SerializeField]
    private int posingSkill;
    [SerializeField]
    private int coins;

    public int PosingSkill
    {
        get
        {
            if (posingSkill == 0 || posingSkill.Equals(null))
            {
                return defaultPosingSkill;
            }
            else
            {
                return posingSkill;
            }
        }
        set { }
    }

    public int Hp
    {
        get
        {
            return hp;
        }
        set
        {
            if (hp == 0 || hp.Equals(null))
            {
                hp = defaultHp;
            }
            else
            {
                hp = value;

            }
        }
    }

    public string Name
    {
        get
        {
            return name;
        }
        set
        {
            if (String.IsNullOrEmpty(value))
            {
                name = defaultName;
            }
            else
            {
                name = value;
            }
        }
    }

    public MuscleSet Muscles
    {
        get { return muscles; }
        set { muscles = value; }
    }

    public List<Item> ActiveItems
    {
        get { return activeItems; }
        set
        {
            if (value is null)
            {
                activeItems = new List<Item>();
            }
            else
            {
                activeItems = value;
            }
        }
    }

    public int Coins
    {
        get { return coins; }
        set { coins = value; }
    }
}