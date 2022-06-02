using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Playables;
using UnityEngine;
using UnityEngine.UI;

public class Fight : MonoBehaviour
{

    public static int Damage;
    public Bodymons Bodymon;
    public Bodymons EnemyBodymon;
    public static string TypeOfAttack;

    bool playerTurn;

    public List<Button> AttackButtons;

    void Start()
    {
        LoadPlayers();
        playerTurn = true;

        //Button btn = ButtonForAttack1.GetComponent<Button>();
        //Debug.Log(ButtonForAttack1.tag);

    }

    static T GetRandomEnum<T>()
    {
        System.Array A = System.Enum.GetValues(typeof(T));
        T V = (T)A.GetValue(UnityEngine.Random.Range(0, A.Length));
        return V;
    }

    public void EnemyTurn()
    {
        Attack(Bodymon.Muscles, EnemyBodymon.Muscles, GetRandomEnum<AttackType>());
    }

    public void ReassignValues()
    {
        foreach (Button b in AttackButtons)
        {
            ButtonInfo binf = b.GetComponent<ButtonInfo>();
            //b.onClick.AddListener(() => { Attack(Bodymon.Muscles, EnemyBodymon.Muscles, b.tag); });
            //b.onClick.AddListener(() => { Debug.Log(b.tag); });
            //Debug.Log(b.tag);

            b.onClick.RemoveAllListeners();
            binf.SetText(binf.TypeOfAttack.ToString());
            b.onClick.AddListener(() => { Attack(Bodymon.Muscles, EnemyBodymon.Muscles, binf.TypeOfAttack); });
        }
    }


    public void Attack(MuscleSet BodymonMS, MuscleSet EnemyBodymonMS, AttackType attackType)
    {
        List<Calculator> lstAlly = new List<Calculator>();
        List<Calculator> lstEnemy = new List<Calculator>();

        MergeValues mrgdV = new MergeValues();


        string[] propertyNames = new string[3];
        double[] allyMultiplier = new double[3];
        double[] enemyMultiplier = new double[3];

        //Recognise what kind of attack was chosen
        switch (attackType)
        {
            case AttackType.frontDoubleBiceps:
                propertyNames = new string[] { "Biceps", "Lat", "Abdominals" };
                allyMultiplier = new double[] { 1.15, 0.45, 0.5 };
                enemyMultiplier = new double[] { 1, 0.3, 0.5 };
                break;
            case AttackType.SideChest:
                propertyNames = new string[] { "Chest", "Biceps", "Abdominals" };
                allyMultiplier = new double[] { 1.75, 1.05, 0.3 };
                enemyMultiplier = new double[] { 1.5, 1, 0.3 };
                break;
            //case "LatSpread":

            //    break;
            
            //case "QuadStomp":

            //    break;
            //case "BackDoubleBiceps":

            //    break;
            //case "DorianEagle":

            //    break;
        }

        for (int i = 0; i < propertyNames.Length; i++)
        {
            lstAlly.Add(new Calculator(GetPropValue(BodymonMS, propertyNames[i]), allyMultiplier[i]));
            lstEnemy.Add(new Calculator(GetPropValue(EnemyBodymonMS, propertyNames[i]), enemyMultiplier[i]));
        }
        mrgdV = new MergeValues(lstAlly, lstEnemy);
        Damage = (int)Calculation(mrgdV);
        Debug.Log("Damage:" + Damage);
        lstAlly.Clear();
        lstEnemy.Clear();
        ////inflict the calculated damage 
        ////EnemyBodymon.Hp =- (int)Damage;
        Debug.Log("Vorher");
        Debug.Log(Bodymon.Hp + ";" + EnemyBodymon.Hp);

        //check if this works plz
        _ = Damage < 0 ? Bodymon.Hp += Damage : EnemyBodymon.Hp += Damage;
        Debug.Log("Nachher");
        Debug.Log(Bodymon.Hp + ";" + EnemyBodymon.Hp);

        if (Bodymon.Hp < 0)
        {
            //ToDo: GameOver
        }
        else if (EnemyBodymon.Hp < 0)
        {
            //ToDo: WON
            Bodymon.Coins += EnemyBodymon.Coins;
        }
    }

    public static double GetPropValue(object src, string propName)
    {
        return (double)src.GetType().GetProperty(propName).GetValue(src, null);
    }

    public static double Calculation(MergeValues mergeValues)
    {
        double valueDamage = 0;
        double valueDamageFromEnemy = 0;

        for (int i = 0; i < mergeValues.Ally.Count; i++)
        {
            valueDamage += mergeValues.Ally[i].MuscleValue * mergeValues.Ally[i].Multiplier;
            valueDamageFromEnemy += mergeValues.Enemy[i].MuscleValue * mergeValues.Enemy[i].Multiplier;
        }

        return valueDamage - valueDamageFromEnemy;
    }

    void LoadPlayers()
    {
        //relative path + without file extension e.g. Enemies/JayCuttler
        EnemyBodymon = Resources.Load<Bodymons>("Enemies/JayCuttler");
        //JsonUtility.FromJsonOverwrite(PlayerPrefs.GetString("markusRühl_bodymon"), EnemyBodymon);
    }
}

public class Calculator
{
    public double MuscleValue { get; set; }
    public double Multiplier { get; set; }

    public Calculator(double muscleValue, double multiplier)
    {
        MuscleValue = muscleValue;
        Multiplier = multiplier;
    }

    public Calculator()
    {

    }
}

public class MergeValues
{
    public List<Calculator> Ally { get; set; }
    public List<Calculator> Enemy { get; set; }

    public MergeValues(List<Calculator> ally, List<Calculator> enemy)
    {
        Ally = ally;
        Enemy = enemy;
    }
    public MergeValues()
    {

    }
}