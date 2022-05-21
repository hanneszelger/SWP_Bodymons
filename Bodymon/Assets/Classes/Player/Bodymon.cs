using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Bodymon : MonoBehaviour
{
    public Bodymons _Bodymons;

    private int defaultHp = 100;
    private string defaultName = "Mwenye Munyaradzi";
    private MuscleSet defaultMuscleset = new MuscleSet();
    private int defaultPosingSkill = 1;

    private int hp;
    private new string name;
    private MuscleSet muscles = new MuscleSet();
    private List<Items> activeItems;
    private int posingSkill;
    private int coins;

    public void Start()
    {
        Hp = _Bodymons.Hp;
        Name = _Bodymons.Name;
        Muscles = _Bodymons.Muscles;
        ActiveItems = _Bodymons.Items;
        PosingSkill = _Bodymons.PosingSkill;
        Coins = _Bodymons.Coins;
    }


    public int Coins
    {
        get { return coins; }
        set { coins = value; }
    }


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

    public List<Items> ActiveItems
    {
        get { return activeItems; }
        set
        {
            if (value is null)
            {
                activeItems = new List<Items>();
            }
            else
            {
                activeItems = value;
            }
        }
    }
}
