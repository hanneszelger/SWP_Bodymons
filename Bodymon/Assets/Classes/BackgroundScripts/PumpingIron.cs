//using System.Collections;
//using System.Collections.Generic;
//using System.Reflection;
//using UnityEngine;
//using UnityEngine.UI;

//public class PumpingIron : MonoBehaviour
//{
//    private GameObject gameObject_player;
//    private GameObject gameObject_gymSpawn;
//    bool inRange;
//    Bodymon player;

//    public GameObject loadingPanel;
//    public Slider loadingBar;
//    public Text progressMade;

//    private float currCountdownValue;
//    private bool currentlyRunning;

//    private AudioSource lightweight;

//    private List<MuscleXGains> MuscleXValue;


//    // Start is called before the first frame update
//    void Start()
//    {
//        gameObject_player = GameObject.FindWithTag("Player");
//        player = gameObject_player.GetComponent<Bodymon>();
//        gameObject_gymSpawn = GameObject.FindWithTag("GymSpawn");

//        loadingPanel.SetActive(false);
//        progressMade.CrossFadeAlpha(0, 0, false);
//        currentlyRunning = false;
//    }

//    void Update()
//    {
        
//        if (Input.GetButtonDown("Interact") && inRange && !currentlyRunning)
//        {
            
//            loadingPanel.SetActive(true);
           
//            StartCoroutine(Progress(10));

//        }
//        if (Input.GetKeyDown(KeyCode.Space))
//        {
//            if (currentlyRunning)
//            {
//                switch (gameObject.tag)
//                {
//                    case "bench":
//                        MuscleXValue = new List<MuscleXGains>() { new MuscleXGains("Chest", 2), new MuscleXGains("Abdominals", 1) };
//                        break;
//                    case "SquatRack":
//                        //ToDo: squat method
//                        break;
//                }

//                string message = "";
//                for (int i = 0; i < MuscleXValue.Count; i++)
//                {
//                    //Debug.Log(MuscleXValue[i].MuscleName);
//                    PropertyInfo propInf = PlayerBodymon.player.Muscles.GetType().GetProperty(MuscleXValue[i].MuscleName);

//                    float calcValue = (float)(loadingBar.value < 0.5 ? 0 : loadingBar.value * MuscleXValue[i].MaxGainsPerLevel);

//                    propInf.SetValue(PlayerBodymon.player.Muscles, (double)calcValue + +(double)propInf.GetValue(PlayerBodymon.player.Muscles, null), null);
//                    message += "+" + string.Format("{0:F1}", calcValue) + " " + MuscleXValue[i].MuscleName + "\n";

//                    if(loadingBar.value == 1)
//                    {
//                        lightweight = GameObject.Find("LightweightBaby").GetComponent<AudioSource>();
//                        lightweight.Play();
//                    }
//                }
//                //Debug.Log(PlayerBodymon.player.Muscles.Chest + ";" + PlayerBodymon.player.Muscles.Abdominals);
//                progressMade.text = message;
//                StartCoroutine(showText());

//                currCountdownValue = 0;
//                MuscleXValue = new List<MuscleXGains>();
//            }

//        }
//    }

//    public void GetPropValue(object src, string propName)
//    {
//        Debug.Log(src.GetType().GetProperty(propName).GetValue(src, null));
//    }



//    public IEnumerator Progress(float countdownValue)
//    {
        
//        currCountdownValue = countdownValue;
//        currentlyRunning = true;
//        while (currCountdownValue > 0)
//        {

//            Debug.Log("Countdown: " + currCountdownValue);
//            loadingBar.value = (countdownValue - currCountdownValue + 1) / countdownValue;
//            yield return new WaitForSeconds(0.2f);
//            currCountdownValue--;
//        }

//        loadingBar.value = 0;
//        loadingPanel.SetActive(false);
//        currentlyRunning = false;
//    }

//    IEnumerator showText()
//    {
//        progressMade.CrossFadeAlpha(1, 1, false);
//        yield return new WaitForSeconds(1);
//        progressMade.CrossFadeAlpha(0, 1, false);
//    }


//    void OnTriggerEnter2D(Collider2D playerCollider)
//    {
//        if (playerCollider.CompareTag("Player"))
//        {
//            inRange = true;
//        }
//    }

//    void OnTriggerExit2D(Collider2D playerCollider)
//    {
//        if (playerCollider.CompareTag("Player"))
//        {
//            inRange = false;
//        }
//    }
//}

//public class MuscleXGains
//{
//    public string MuscleName;
//    public double MaxGainsPerLevel;

//    public MuscleXGains(string _muscleName, double _maxGainsPerLevel)
//    {
//        MuscleName = _muscleName;
//        MaxGainsPerLevel = _maxGainsPerLevel;
//    }
//}
