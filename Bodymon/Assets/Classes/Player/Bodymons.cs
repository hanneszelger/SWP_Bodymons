using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName = "ScriptableObject/Bodymons", fileName = "Bodymon", order = 0)]
public class Bodymons : ScriptableObject
{
    public int hp;
    public new string name;
    public bool owned;
    public MuscleSet muscles;
    public List<Item> activeItems;
    public int posingSkill;
}