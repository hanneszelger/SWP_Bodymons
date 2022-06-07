﻿using System.Collections;
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
        ChangeText();
        Zyzz.enabled = false;
    }

    public void ChangeText()
    {
        label.text = labels[Random.Range(0, labels.Length)];
    }

    public void NewLevel()
    {
       
        SceneManager.LoadScene(SaveAndRestorePosition.lastSceneForMenu, LoadSceneMode.Single); 
        
    }

    public void LoadLevel()
    {
        //Load level
    }

    public void ShowOptions()
    {
        mainMenu.SetActive(false);
        optionsMenu.SetActive(true);
    }

    public void HideOptions()
    {
        optionsMenu.SetActive(false);
        mainMenu.SetActive(true);
        ChangeText();
    }

    public void ToggleZyzz()
    {
        if(!Zyzz.enabled)
            StartCoroutine(ShowZyzzXSec(2));
    }

    public IEnumerator ShowZyzzXSec(byte seconds)
    {
        Zyzz.enabled = true;
        yield return new WaitForSeconds(seconds);
        Zyzz.enabled = false;
    }

    public void SwitchMusic()
    {
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
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            optionsMenu.SetActive(false);
            mainMenu.SetActive(true);
            ChangeText();
        }
    }
}
