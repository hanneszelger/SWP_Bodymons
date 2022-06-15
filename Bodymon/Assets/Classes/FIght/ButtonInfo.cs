using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonInfo : MonoBehaviour
{
    public AttackType TypeOfAttack;

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
