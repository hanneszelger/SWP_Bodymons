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
        SaveGame.AddItemToInventory(trenItem);
    }

    // Update is called once per frame
    void Update()
    {
        int luck = Random.Range(1, 10);
        if (dialogActive && Input.GetKeyDown(KeyCode.Space) && exitScene)
        {
            //SceneManager.LoadScene(0, LoadSceneMode.Additive);
            //GameObject gameObject_player = GameObject.FindWithTag("Player");
            //gameObject_player.transform.position = new Vector3(-13.77f, 18.6f, -2);
            //Debug.Log(gameObject_player.name);
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

