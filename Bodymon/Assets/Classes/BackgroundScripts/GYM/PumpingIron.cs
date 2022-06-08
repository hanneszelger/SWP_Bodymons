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
    Bodymon player;

    public GameObject loadingPanel;
    public Slider loadingBar;
    public Text progressMade;

    private float currCountdownValue;
    private bool currentlyRunning;

    private List<MuscleXGains> MuscleXValue;
    private string currentTag;


    // Start is called before the first frame update
    void Start()
    {
        gameObject_player = GameObject.FindWithTag("Player");
        player = gameObject_player.GetComponent<Bodymon>();
        gameObject_gymSpawn = GameObject.FindWithTag("GymSpawn");

        loadingPanel.SetActive(false);
        progressMade.CrossFadeAlpha(0, 0, false);
        currentlyRunning = false;

        ContinueGame();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetButtonDown("Interact"))
        {
            //if (currentlyRunning)
            //{
                float tempCalc = 0;
            switch (currentTag)
            {
                case "bench":
                    if (currentlyRunning)
                    {
                        MuscleXValue = new List<MuscleXGains>() { new MuscleXGains("Chest", 3), new MuscleXGains("Abdominals", 1) };
                        tempCalc = (float)(loadingBar.value < 0.5 ? 0 : (float)loadingBar.value);
                        GetGainz(tempCalc);
                    }
                    else if (!currentlyRunning)
                    {
                        loadingPanel.SetActive(true);
                        StartCoroutine(Progress(10));
                    }
                    break;
                case "gym_squat":
                    MinigameSave.muscleGains = new List<MuscleXGains>() { new MuscleXGains("Quads", 3), new MuscleXGains("Abdominals", 1.5) };
                    MinigameSave.lastPlayerPosition = gameObject_player.transform.position;
                    SceneManager.LoadScene(6, LoadSceneMode.Single);
                    break;
            }
        }
    }

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
        if (MuscleXValue is not null)
            for (int i = 0; i < MuscleXValue.Count; i++)
            {
                //Debug.Log(MuscleXValue[i].MuscleName);
                PropertyInfo propInf = PlayerBodymon.player.Muscles.GetType().GetProperty(MuscleXValue[i].MuscleName);

                calcValue = calcValue * (float)MuscleXValue[i].MaxGainsPerLevel;

                propInf.SetValue(PlayerBodymon.player.Muscles, (double)calcValue + +(double)propInf.GetValue(PlayerBodymon.player.Muscles, null), null);
                message += "+" + string.Format("{0:F1}", calcValue) + " " + MuscleXValue[i].MuscleName + "\n";

            }
        //Debug.Log(PlayerBodymon.player.Muscles.Chest + ";" + PlayerBodymon.player.Muscles.Abdominals);
        Debug.Log(message);
        progressMade.text = message;
        StartCoroutine(showText());

        currCountdownValue = 0;
        MuscleXValue = new List<MuscleXGains>();
        MinigameSave.stillOpen = false;
    }

    public void GetPropValue(object src, string propName)
    {
        Debug.Log(src.GetType().GetProperty(propName).GetValue(src, null));
    }



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

        loadingBar.value = 0;
        loadingPanel.SetActive(false);
        currentlyRunning = false;
    }

    IEnumerator showText()
    {
        progressMade.CrossFadeAlpha(1, 1, false);
        yield return new WaitForSeconds(1);
        progressMade.CrossFadeAlpha(0, 1, false);
    }

    public void PlayerNowInRange(string GameTag)
    {
        inRange = true;
        currentTag = GameTag;
    }

    public void PlayerNowOutOfRange()
    {
        inRange = false;
        currentTag = "";
    }

    //public void OnTriggerEnter2D(Collider2D playerCollider)
    //{
    //    if (playerCollider.CompareTag("Player"))
    //    {
    //        inRange = true;
    //    }
    //}

    //public void OnTriggerExit2D(Collider2D playerCollider)
    //{
    //    if (playerCollider.CompareTag("Player"))
    //    {
    //        inRange = false;
    //    }
    //}
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

public static class MinigameSave
{
    public static Vector3 lastPlayerPosition;
    public static float GainsMultiplier;
    public static List<MuscleXGains> muscleGains;
    public static bool stillOpen;
}
