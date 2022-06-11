using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Fight : MonoBehaviour
{

    public static int Damage;
    public Bodymons Bodymon;
    public Bodymons EnemyBodymon;
    public static string TypeOfAttack;

    bool playerTurn;

    public List<Button> AttackButtons;
    public Text DamageDelt;

    public Text AllyHP;
    public Text EnemyHP;

    void Start()
    {
        //LoadPlayers();
        Bodymon.Hp = 100;
        EnemyBodymon.Hp = 100;
        playerTurn = true;
        ReassignValues();
        //Button btn = ButtonForAttack1.GetComponent<Button>();
        //Debug.Log(ButtonForAttack1.tag);
    }
    
    static T GetRandomEnum<T>()
    {
        System.Array A = System.Enum.GetValues(typeof(T));
        T V = (T)A.GetValue(UnityEngine.Random.Range(0, A.Length));
        return V;
    }

    public IEnumerator EnemyTurn(Button enableAgain)
    {
        
        toggleButtonActive();
        yield return new WaitForSeconds(1.5f);
        Attack(Bodymon.Muscles, EnemyBodymon.Muscles, GetRandomEnum<AttackType>());
        yield return new WaitForSeconds(1.5f);
        toggleButtonActive();
        ReassignValues();
    }

    public void ReassignValues()
    {
        List<AttackType> at = new List<AttackType>();
        foreach (Button b in AttackButtons)
        {
            ButtonInfo binf = b.GetComponent<ButtonInfo>();

            do
            {
                binf.TypeOfAttack = GetRandomEnum<AttackType>();
            } while (at.Contains(binf.TypeOfAttack));

            at.Add(binf.TypeOfAttack);
 
            playerTurn = true;

            b.onClick.RemoveAllListeners();

            var val = binf.TypeOfAttack.ToString();
            val = string.Concat(val.Select(x => Char.IsUpper(x) ? " " + x : x.ToString())).TrimStart(' ');

            binf.SetText(val);

            b.onClick.AddListener(() => {
                if(playerTurn)Attack(Bodymon.Muscles, EnemyBodymon.Muscles, binf.TypeOfAttack);
                playerTurn = false;

                StartCoroutine(EnemyTurn(b));         
            });
        }
    }

    public void toggleButtonActive()
    {
        foreach (Button b in AttackButtons)
        {
            b.interactable = !b.interactable;
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
            case AttackType.FrontDoubleBiceps:
                propertyNames = new string[] { "Biceps", "Lat", "Abdominals" };
                allyMultiplier = new double[] { 1.15, 0.45, 0.5 };
                enemyMultiplier = new double[] { 1, 0.3, 0.5 };
                break;
            case AttackType.SideChest:
                propertyNames = new string[] { "Chest", "Biceps", "Abdominals" };
                allyMultiplier = new double[] { 1.75, 1.05, 0.3 };
                enemyMultiplier = new double[] { 1.5, 1, 0.3 };
                break;
            case AttackType.LatSpread:
                propertyNames = new string[] { "Lat", "Biceps", "Abdominals" };
                allyMultiplier = new double[] { 1.8, 1.05, 0.7 };
                enemyMultiplier = new double[] { 1.5, 1, 0.7 };
                break;

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
        lstAlly.Clear();
        lstEnemy.Clear();
        ////inflict the calculated damage 
        ////EnemyBodymon.Hp =- (int)Damage;

        //check if this works plz
         _ = Damage < 0 ? Bodymon.Hp += Damage : EnemyBodymon.Hp -= Damage;

        DamageDelt.text = Damage.ToString();

        EnemyHP.text = EnemyBodymon.Hp.ToString();
        AllyHP.text = Bodymon.Hp.ToString();


        if (Bodymon.Hp <= 0)
        {
            //ToDo: GameOver
            Debug.Log("LOST");
            SceneManager.LoadSceneAsync(8,LoadSceneMode.Single);
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
        Debug.Log("allyDamage: " +valueDamage);
        Debug.Log("enemyDamage: " + valueDamageFromEnemy);
        return valueDamage - valueDamageFromEnemy;
    }

    void LoadPlayers()
    {
        //relative path + without file extension e.g. Enemies/JayCuttler
        //EnemyBodymon = Resources.Load<Bodymons>("Enemies/JayCuttler");
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