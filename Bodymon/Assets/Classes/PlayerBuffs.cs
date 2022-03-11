using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBuffs
{
    private double anabol;

    public double Anabol
    {
        get { return anabol; }
        set { anabol = value; }
    }

    private double hpBoost;

    public double HpBoost
    {
        get { return hpBoost; }
        set { hpBoost = value; }
    }

    private double proteinSynthesis;

    public double ProteinSynthesis
    {
        get { return proteinSynthesis; }
        set { proteinSynthesis = value; }
    }

}
