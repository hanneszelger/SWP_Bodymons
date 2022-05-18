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
    private List<Item> activeItems;
    private int posingSkill;
    private int coins;

    private void Start()
    {
        Hp = _Bodymons.hp;
        Name = _Bodymons.name;
        Muscles = _Bodymons.muscles;
        ActiveItems = _Bodymons.activeItems;
        PosingSkill = _Bodymons.posingSkill;
        Coins = _Bodymons.coins;
    }

    [SerializeField]
    public int Coins
    {
        get { return coins; }
        set { coins = value; }
    }


    [SerializeField]
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

    [SerializeField]
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

    [SerializeField]
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

    [SerializeField]
    public MuscleSet Muscles
    {
        get { return muscles; }
        set { muscles = value; }
    }

    [SerializeField]
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
}
