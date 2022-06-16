using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PumpingIron : MonoBehaviour
{
    private GameObject gameObject_player;
    private GameObject gameObject_gymSpawn;

    [System.NonSerialized]
    public bool inRange;

    public GameObject loadingPanel;
    public Slider loadingBar;
    public Text progressMade;
    private AudioSource lightweight;

    private float currCountdownValue;
    private bool currentlyRunning;

    private List<MuscleXGains> MuscleXValue;
    private string currentTag;

    // Start is called before the first frame update
    private void Start()
    {
        //Gets the gameobjects from the scene
        gameObject_player = GameObject.FindWithTag("Player");
        gameObject_gymSpawn = GameObject.FindWithTag("GymSpawn");

        loadingPanel.SetActive(false);
        progressMade.CrossFadeAlpha(0, 0, false);
        currentlyRunning = false;

        ContinueGame();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetButtonDown("Interact"))
        {
            float tempCalc = 0;
            switch (currentTag)
            {
                case "bench":
                    if (currentlyRunning)
                    {
                        MuscleXValue = new List<MuscleXGains>() { new MuscleXGains("Chest", 3), new MuscleXGains("Abdominals", 0.75) };
                        tempCalc = (float)(loadingBar.value < 0.5 ? 0 : (float)loadingBar.value);
                        if (loadingBar.value == 1)
                        {
                            lightweight = GameObject.Find("LightweightBaby").GetComponent<AudioSource>();
                            lightweight.Play();
                        }
                        GetGainz(tempCalc);
                    }
                    else if (!currentlyRunning)
                    {
                        loadingPanel.SetActive(true);
                        StartCoroutine(Progress(10));
                    }
                    break;

                case "gym_squat":
                    MinigameSave.muscleGains = new List<MuscleXGains>() { new MuscleXGains("Quads", 3), new MuscleXGains("Abdominals", 1.1) };
                    MinigameSave.lastPlayerPosition = gameObject_player.transform.position;
                    SceneManager.LoadScene(6, LoadSceneMode.Single);
                    break;

                case "gym_row":
                    MinigameSave.muscleGains = new List<MuscleXGains>() { new MuscleXGains("Lat", 7), new MuscleXGains("Biceps", 3.5) };
                    MinigameSave.lastPlayerPosition = gameObject_player.transform.position;
                    SceneManager.LoadScene(7, LoadSceneMode.Single);
                    break;
            }
        }
    }

    //multiplies the values
    public void ContinueGame()
    {
        if (MinigameSave.stillOpen)
        {
            gameObject_player.transform.position = MinigameSave.lastPlayerPosition;
            MuscleXValue = MinigameSave.muscleGains;
            GetGainz(MinigameSave.GainsMultiplier);
        }
    }

    private void GetGainz(float calcValue)
    {
        string message = "";
        float strengtBonus = 0;

        // iterates trhough the items, checks its buffs and adds the strength buff
        foreach (Items actItem in PlayerBodymon.player.Items)
        {
            foreach (ItemBuff activeBuff in actItem.ItemBuffs)
            {
                if (activeBuff.TypeOfBuff == Buffstyle.Strength)
                {
                    strengtBonus += activeBuff.value;
                }
            }
        }

        // adjust the multiplier for the bouns
        strengtBonus = 1 + strengtBonus * 0.015f;

        // Calculates the Values and adds it to the message
        if (MuscleXValue is not null)
            for (int i = 0; i < MuscleXValue.Count; i++)
            {
                //Debug.Log(MuscleXValue[i].MuscleName);
                PropertyInfo propInf = PlayerBodymon.player.Muscles.GetType().GetProperty(MuscleXValue[i].MuscleName);

                float gainsMade = calcValue * strengtBonus * (float)MuscleXValue[i].MaxGainsPerLevel;
                Debug.Log((double)propInf.GetValue(PlayerBodymon.player.Muscles));

                propInf.SetValue(PlayerBodymon.player.Muscles, (double)gainsMade + (double)propInf.GetValue(PlayerBodymon.player.Muscles, null), null);
                message += "+" + string.Format("{0:F1}", gainsMade) + " " + MuscleXValue[i].MuscleName + "\n";
            }
        //Debug.Log(PlayerBodymon.player.Muscles.Chest + ";" + PlayerBodymon.player.Muscles.Abdominals);
        Debug.Log(message);
        progressMade.text = message;
        StartCoroutine(showText());

        //Resets Values
        currCountdownValue = 0;
        MuscleXValue = new List<MuscleXGains>();
        MinigameSave.stillOpen = false;
    }

    public void GetPropValue(object src, string propName)
    {
        Debug.Log(src.GetType().GetProperty(propName).GetValue(src, null));
    }

    /// <summary>
    /// Increases the value of the loadingBar ever 0.2 seconds
    /// </summary>
    /// <param name="countdownValue"></param>
    /// <returns></returns>
    public IEnumerator Progress(float countdownValue)
    {
        currCountdownValue = countdownValue;
        currentlyRunning = true;
        while (currCountdownValue > 0)
        {
            //Debug.Log("Countdown: " + currCountdownValue);
            loadingBar.value = (countdownValue - currCountdownValue + 1) / countdownValue;
            yield return new WaitForSeconds(0.2f);
            currCountdownValue--;
        }

        // makes loadingBar the invisible and currentlyRunning -> false
        loadingBar.value = 0;
        loadingPanel.SetActive(false);
        currentlyRunning = false;
    }

    // fades progressBar in, out and shows it for 1 sec
    private IEnumerator showText()
    {
        progressMade.CrossFadeAlpha(1, 1, false);
        yield return new WaitForSeconds(1);
        progressMade.CrossFadeAlpha(0, 1, false);
    }

    /// <summary>
    /// Sets inRange true and sets tag of machine
    /// </summary>
    /// <param name="GameTag"></param>
    public void PlayerNowInRange(string GameTag)
    {
        inRange = true;
        currentTag = GameTag;
    }

    /// <summary>
    /// Sets InRange false and removes currentTag
    /// </summary>
    public void PlayerNowOutOfRange()
    {
        inRange = false;
        currentTag = "";
    }
}

public class MuscleXGains
{
    public string MuscleName;
    public double MaxGainsPerLevel;

    public MuscleXGains(string _muscleName, double _maxGainsPerLevel)
    {
        MuscleName = _muscleName;
        MaxGainsPerLevel = _maxGainsPerLevel;
    }
}

//Stores data while in Minigame
public static class MinigameSave
{
    public static Vector3 lastPlayerPosition;
    public static float GainsMultiplier;
    public static List<MuscleXGains> muscleGains;
    public static bool stillOpen;
}