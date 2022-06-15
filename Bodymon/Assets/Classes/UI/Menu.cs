using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public GameObject mainMenu;
    public GameObject optionsMenu;
    public static bool MainTracks = true;

    public Text label;

    public string[] labels = { "Lightweight Baby!", "Not Pokemon", "Not Block Game!", "Zyzz", "Plates=Dates" };

    public AudioSource musicSource;
    public Text musicText;

    public AudioSource soundSource;
    public Text soundText;
    public Image Zyzz;

    public Text invertText;
    public Text distanceText;
    public Text dimensionText;
    public Text difficultyText;
    public Text fPSText;
    public Text bobbingText;
    public Text limitText;

    void Start()
    {
        //Calling ChangeText() to change animated label
        ChangeText();
        //Picture will be set to enabled once button "Aufgeben" has been clicked
        Zyzz.enabled = false;
    }

    public void ChangeText()
    {
        //Changes the BlockGameLike Label to a random Text from an array
        label.text = labels[Random.Range(0, labels.Length)];
    }

    public void NewLevel()
    {
        //Player gets created
        PlayerBodymon.player = ScriptableObject.CreateInstance<Bodymons>();
        SaveGame.SavePlayer();
        //Loads Main scene
        SceneManager.LoadScene(SaveAndRestorePosition.lastSceneForMenu, LoadSceneMode.Single); 
    }

    public void LoadLevel()
    {
        //Load level
    }

    public void ShowOptions()
    {
        //Optionsmenu gets visible
        mainMenu.SetActive(false);
        optionsMenu.SetActive(true);
    }

    public void HideOptions()
    {
        //Optionsmenu gets invisible
        optionsMenu.SetActive(false);
        mainMenu.SetActive(true);
        ChangeText();
    }

    public void ToggleZyzz()
    {
        //Shows a Picture of a motivating Zyzz for 2 Seconds
        if(!Zyzz.enabled)
            StartCoroutine(ShowZyzzXSec(2));
    }

    public IEnumerator ShowZyzzXSec(byte seconds)
    {
        //Zyzz will be shown here for however seconds
        Zyzz.enabled = true;
        yield return new WaitForSeconds(seconds);
        Zyzz.enabled = false;
    }

    public void SwitchMusic()
    {
        //Background Music will be turned on/off depending on buttonsetting
        if(musicSource.volume > 0)
        {
            musicSource.volume = 0;
            musicText.text = "Musik: AUS";
            MainTracks = false;
        }
        else
        {
            musicSource.volume = 1;
            musicText.text = "Musik: AN";
            MainTracks = true;
        }
    }

    public void SwitchSounds()
    {
        //Klicking Sounds will be turned on/off depending on buttonsetting
        if (soundSource.volume > 0)
        {
            soundSource.volume = 0;
            soundText.text = "Sound: AUS";
        }
        else
        {
            soundSource.volume = 1;
            soundText.text = "Sound: AN";
        }
    }

    public void ChangeFOV()
    {
        //Only button text changes by now
        if (distanceText.text == "Render Distanz: WEIT")
        {
            distanceText.text = "Render Distanz: KURZ";
        }
        else if (distanceText.text == "Render Distanz: KURZ")
        {
            distanceText.text = "Render Distanz: MITTEL";
        }
        else
        {
            distanceText.text = "Render Distanz: WEIT";
        }
    }
    void Update()
    {
        //Return from options with escape button
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            optionsMenu.SetActive(false);
            mainMenu.SetActive(true);
            ChangeText();
        }
    }
}
