using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonInfo : MonoBehaviour
{
    public AttackType TypeOfAttack;

    //allows different script to set text
    public void SetText(string text)
    {
        Text temp = GetComponentInChildren<Text>();
        temp.text = text;
    }
}

public enum AttackType
{
    FrontDoubleBiceps,
    SideChest,
    LatSpread,
    QuadStomp
}
