using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Fight : MonoBehaviour
{

    public static int Damage;
    public Bodymons Bodymon;
    public Bodymons EnemyBodymon;
    public static string TypeOfAttack;

    public Button ButtonForAttack1;

    void Start()
    {
        LoadPlayers();

        //Button btn = ButtonForAttack1.GetComponent<Button>();
        ButtonForAttack1.onClick.AddListener(() => { Attack(Bodymon.Muscles, EnemyBodymon.Muscles, "fight_FrontDoubleBiceps"); });
        //Debug.Log(ButtonForAttack1.tag);
    }


    public void Attack(MuscleSet BodymonMS, MuscleSet EnemyBodymonMS, string TypeOfAttack)
    {
        List<Calculator> lstAlly = new List<Calculator>();
        List<Calculator> lstEnemy = new List<Calculator>();

        MergeValues mrgdV = new MergeValues();


        string[] propertyNames = new string[3];
        double[] allyMultiplier = new double[3];
        double[] enemyMultiplier = new double[3];

        //Recognise what kind of attack was chosen
        switch (TypeOfAttack)
        {
            case "fight_FrontDoubleBiceps":
                propertyNames = new string[] { "Biceps", "Lat", "Abdominals" };
                allyMultiplier = new double[] { 1.15, 0.45, 0.5 };
                enemyMultiplier = new double[] { 1, 0.3, 0.5 };
                break;
            case "LatSpread":

                break;
            case "SideChest":

                break;
            case "QuadStomp":

                break;
            case "BackDoubleBiceps":

                break;
            case "DorianEagle":

                break;
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


    #region old
    //public static double FrontDoubleBiceps(MuscleSet BodymonParameter, MuscleSet EnemyBodymon)
    //{
    //	//allied bodymon 
    //	double ValueDamage = BodymonParameter.Biceps * 1.15 + BodymonParameter.Lat * 0.45 + BodymonParameter.Abdominals * 0.5;
    //	//enemy bodymon
    //	double ValueDamageFromEnemy = EnemyBodymon.Biceps * 1 + EnemyBodymon.Lat * 0.3 + EnemyBodymon.Abdominals * 0.5;
    //	//total damage, that will be dealt to enemy 
    //	double TotalDamage = ValueDamage - ValueDamageFromEnemy;
    //	return TotalDamage;
    //}

    //public static double LatSpread(Bodymon BodymonParameter, Bodymon EnemyBodymon)
    //{
    //	//allied bodymon 
    //	double ValueDamage = BodymonParameter.Muscles.Biceps * 0.6 + BodymonParameter.Muscles.Lat * 1.75 + BodymonParameter.Muscles.Abdominals * 1;
    //	//enemy bodymon
    //	double ValueDamageFromEnemy = EnemyBodymon.Muscles.Biceps * 0.4 + EnemyBodymon.Muscles.Lat * 1.25 + EnemyBodymon.Muscles.Abdominals * 0.5;
    //	//total damage, that will be dealt to enemy 
    //	double TotalDamage = ValueDamage - ValueDamageFromEnemy;
    //	return TotalDamage;
    //}

    //public static double SideChest(Bodymon BodymonParameter, Bodymon EnemyBodymon)
    //{
    //	//allied bodymon 
    //	double ValueDamage = BodymonParameter.Muscles.Biceps * 0.75 + BodymonParameter.Muscles.Lat * 0.1 + BodymonParameter.Muscles.Chest * 2;
    //	//enemy bodymon
    //	double ValueDamageFromEnemy = EnemyBodymon.Muscles.Biceps * 0.25 + EnemyBodymon.Muscles.Lat * 0.01 + EnemyBodymon.Muscles.Chest * 1.5;
    //	//total damage, that will be dealt to enemy 
    //	double TotalDamage = ValueDamage - ValueDamageFromEnemy;
    //	return TotalDamage;
    //}

    //public static double QuadStomp(Bodymon BodymonParameter, Bodymon EnemyBodymon)
    //{
    //	//allied bodymon 
    //	double ValueDamage = BodymonParameter.Muscles.Quads * 2 + BodymonParameter.Muscles.Lat * 0.5 + BodymonParameter.Muscles.Abdominals * 0.75;
    //	//enemy bodymon
    //	double ValueDamageFromEnemy = EnemyBodymon.Muscles.Quads * 1 + EnemyBodymon.Muscles.Lat * 0.35 + EnemyBodymon.Muscles.Abdominals * 0.6;
    //	//total damage, that will be dealt to enemy 
    //	double TotalDamage = ValueDamage - ValueDamageFromEnemy;
    //	return TotalDamage;
    //}

    //public static double BackDoubleBiceps(Bodymon BodymonParameter, Bodymon EnemyBodymon)
    //{
    //	//allied bodymon 
    //	double ValueDamage = BodymonParameter.Muscles.Biceps * 1.5 + BodymonParameter.Muscles.Lat * 2 + BodymonParameter.Muscles.Quads * 0.1;
    //	//enemy bodymon
    //	double ValueDamageFromEnemy = EnemyBodymon.Muscles.Biceps * 0.5 + EnemyBodymon.Muscles.Lat * 1 + EnemyBodymon.Muscles.Abdominals * 0.01;
    //	//total damage, that will be dealt to enemy 
    //	double TotalDamage = ValueDamage - ValueDamageFromEnemy;
    //	return TotalDamage;
    //}

    //public static double DorianEagle(Bodymon BodymonParameter, Bodymon EnemyBodymon)
    //{
    //	//allied bodymon 
    //	double ValueDamage = BodymonParameter.Muscles.Biceps * 1 + BodymonParameter.Muscles.Lat * 1.5 + BodymonParameter.Muscles.Abdominals * 0.2;
    //	//enemy bodymon
    //	double ValueDamageFromEnemy = EnemyBodymon.Muscles.Biceps * 0.5 + EnemyBodymon.Muscles.Lat * 0.5 + EnemyBodymon.Muscles.Abdominals * 0.1;
    //	//total damage, that will be dealt to enemy 
    //	double TotalDamage = ValueDamage - ValueDamageFromEnemy;
    //	return TotalDamage;
    //}
    #endregion
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