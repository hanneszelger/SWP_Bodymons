using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DialogueManagerDealer : MonoBehaviour
{
    public GameObject dBox;
    public Text dText;

    public bool dialogActive;
    public bool exitScene = false;
    public AudioSource audioSource;
    public AudioClip[] audioClipArray;
    AudioClip lastClip;

    public Items trenItem;

    // Start is called before the first frame update
    void Start()
    {
        audioSource.PlayOneShot(RandomClip());
    }

    private void OnDestroy()
    {
        //Saves the new inventory when the scene finishes
        SaveGame.SavePlayer();
    }

    // Update is called once per frame
    void Update()
    {
        
        if (dialogActive && Input.GetKeyDown(KeyCode.Space) && exitScene)
        {
            //Changes the Scene to the main scene
            audioSource.PlayOneShot(RandomClip());
            SavedPositionManager.lastScene = 4;
            SceneManager.LoadScene(0, LoadSceneMode.Single);
        }
        if (dialogActive && Input.GetKeyDown(KeyCode.Space) && !exitScene)
        {
            dText.text = "Willst du so richtig schnell so richtig breit werden?\nWenn ja würde ich dir Trenbalone empfehlen, was\ndich 100 Coins kosten würde. (J/N)";
            audioSource.PlayOneShot(RandomClip());
        }
        if (Input.GetKeyDown("j"))
        {
            dText.text = "Gute Entscheidung!...\n\nBye!";
            //Adds Item to the inventory
            SaveGame.AddItemToInventory(trenItem);
            audioSource.clip = audioClipArray[6];
            audioSource.Play();
            exitScene = true;
        }
        if (Input.GetKeyDown("n"))
        {
            dText.text = "Ok, looser schönen Tag noch!";
            audioSource.clip = audioClipArray[5];
            audioSource.Play();
            exitScene = true;
        }
    }

    
    AudioClip RandomClip()
    {
        //Chooses random audioclip of an array
        int attempts = 3;
        AudioClip newClip = audioClipArray[Random.Range(0, audioClipArray.Length-2)];
        while (newClip == lastClip && attempts > 0)
        {
            newClip = audioClipArray[Random.Range(0, audioClipArray.Length-2)];
            attempts--;
        }
        lastClip = newClip;
        return newClip;
    }
}

