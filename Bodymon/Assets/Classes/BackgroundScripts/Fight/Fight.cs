using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Fight : MonoBehaviour
{
    //declare variables
    public static int Damage;

    public Bodymons Bodymon;
    public Bodymons EnemyBodymon;
    public static string TypeOfAttack;

    private bool playerTurn;

    public List<Button> AttackButtons;
    public Text DamageDelt;

    public Text AllyHP;
    public Text EnemyHP;

    public Text WinLoose;
    public Text CoinsWon;

    private void Start()
    {
        //LoadPlayers();
        Bodymon.Hp = 100;
        EnemyBodymon.Hp = 100;
        playerTurn = true;
        ReassignValues();
        Bodymon = PlayerBodymon.player;

        //hides text
        WinLoose.CrossFadeAlpha(0, 0, false);
        CoinsWon.CrossFadeAlpha(0, 0, false);
    }

    private static T GetRandomEnum<T>()
    {
        //Get Values from the Enum as array and chooses as well as returns random item
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

            b.onClick.AddListener(() =>
            {
                if (playerTurn) Attack(Bodymon.Muscles, EnemyBodymon.Muscles, binf.TypeOfAttack);
                playerTurn = false;

                StartCoroutine(EnemyTurn(b));
            });
        }
    }

    /// <summary>
    /// Toggles interactable state of all AttackButtons
    /// </summary>
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

            case AttackType.QuadStomp:
                propertyNames = new string[] { "Quads", "Chest", "Abdominals" };
                allyMultiplier = new double[] { 1.8, 0.7, 1.0 };
                enemyMultiplier = new double[] { 1.5, 0.65, 1.0 };
                break;
        }

        //Gets all Muscles with values and multipliers from Enemy and Ally Bodymon
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

        //Checks if player wins or looses
        if (Bodymon.Hp <= 0)
        {
            StartCoroutine(showResult(false));
        }
        else if (EnemyBodymon.Hp <= 0)
        {
            Bodymon.Coins += EnemyBodymon.Coins;
            CoinsWon.text = EnemyBodymon.Coins.ToString();
            StartCoroutine(showResult(true));
        }
    }

    IEnumerator showResult(bool won)
    {
        WinLoose.text = won ? "WON" : "LOST";
        CoinsWon.CrossFadeAlpha(1, 1, false);
        WinLoose.CrossFadeAlpha(1, 1, false);
        yield return new WaitForSeconds(2);
        SceneManager.LoadSceneAsync(8, LoadSceneMode.Single);
    }

    public static double GetPropValue(object src, string propName)
    {
        return (double)src.GetType().GetProperty(propName).GetValue(src, null);
    }

    /// <summary>
    /// Calculates effective Damage
    /// </summary>
    /// <param name="mergeValues"></param>
    /// <returns>Damage dealt to Enemy -> if negative self damage</returns>
    public static double Calculation(MergeValues mergeValues)
    {
        double valueDamage = 0;
        double valueDamageFromEnemy = 0;

        //go through all the items and multiply the muscle values with the multipliers for the total damage output
        for (int i = 0; i < mergeValues.Ally.Count; i++)
        {
            valueDamage += mergeValues.Ally[i].MuscleValue * mergeValues.Ally[i].Multiplier;
            valueDamageFromEnemy += mergeValues.Enemy[i].MuscleValue * mergeValues.Enemy[i].Multiplier;
        }
        return valueDamage - valueDamageFromEnemy;
    }
}

/// <summary>
/// Combines muscle value with the multiplier
/// </summary>
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

/// <summary>
/// Merges the enemy and ally values into one list
/// </summary>
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