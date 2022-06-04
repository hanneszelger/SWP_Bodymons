using DigitalRuby.LightningBolt;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaitForThunder : MonoBehaviour
{
    private LightningBoltScript _lightningBoltScript;
    
    public Text timerText;
    private float currentTime = 0;
    private float step = 1f;

    public GameObject loadingPanel;
    public Slider loadingBar;
    public Text progressMade;
    private float Timeleft;

    private void Start()
    {
        loadingBar.value = 0;
        loadingBar.maxValue = 11;
        loadingBar.minValue = 0;
        Timeleft = 10;

        _lightningBoltScript = GameObject.Find("SimpleLightningBoltAnimatedPrefab").GetComponent<LightningBoltScript>();
        loadingPanel.SetActive(true);
        loadingBar.gameObject.SetActive(true);
        
        progressMade.gameObject.SetActive(true);
        //StartCoroutine(TimerRoutine());
        _lightningBoltScript.Trigger();
    }

    public IEnumerator TimerRoutine()
    {
        while (currentTime < 10) 
        {
            _lightningBoltScript.Trigger();
            yield return new WaitForSeconds(step);
            _lightningBoltScript.Trigger();
            currentTime += step;
            loadingBar.value += step;
            Timeleft -=1;
            _lightningBoltScript.Trigger();
            progressMade.text = "Zeit bis zum Rückruf: "+Timeleft.ToString();
        }
        if (currentTime > 9)
        {
            GameObject gameObject_player = GameObject.FindWithTag("Player");
            gameObject_player.transform.position = new Vector3(-13.77f, 1.3f, -2);
            Camera.main.transform.position = new Vector3(-13.5f, 1.68f, -10);

            
            StopCoroutine(TimerRoutine());
            currentTime = 0;
            loadingBar.value = 0;
            loadingBar.maxValue = 11;
            loadingBar.minValue = 0;
            Timeleft = 10;
            toggleGUI(true);
            
        }

    }
    public static void toggleGUI(bool nothing)
    {
        if (nothing)
        {
            Debug.Log("Has changed to 0");
            GameObject.Find("LoadingPanel").transform.localScale = new Vector3(0, 0, 0);
            GameObject.Find("Slider").transform.localScale = new Vector3(0, 0, 0);
            GameObject.Find("Text").transform.localScale = new Vector3(0, 0, 0);
        }
        if (!nothing)
        {
            GameObject.Find("LoadingPanel").transform.localScale = new Vector3((float)1.7, 1, 1);
            GameObject.Find("Slider").transform.localScale = new Vector3(1, 1, 1);
            GameObject.Find("Text").transform.localScale = new Vector3((float)1.43, (float)1.43, (float)1.43); 
        }
    }
}

