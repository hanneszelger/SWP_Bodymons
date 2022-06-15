using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{

    public GameObject dBox;
    public Text dText;

    public bool dialogActive;
    public bool exitScene = false;

    public AudioSource audioSource;
    public AudioClip[] audioClipArray;
    AudioClip lastClip;

    public Items SwagFlyHighs;

    // Start is called before the first frame update
    void Start()
    {
        //Play a random sound of an array of soundclips
        audioSource.PlayOneShot(RandomClip());
    }

    // Update is called once per frame
    void Update()
    {
        //Luck decides if you get a debuff or a buff
        int luck = Random.Range(1, 10);
        if (dialogActive && Input.GetKeyDown(KeyCode.Space) && exitScene)
        {
            //switches back to main scene
            SceneManager.LoadScene(0, LoadSceneMode.Single);
        }
        if (dialogActive && Input.GetKeyDown(KeyCode.Space) && !exitScene)
        {
            //Asks the first question
            audioSource.Stop();
            dText.text = "Willst du wissen wie es dir geht? (J/N)";
            audioSource.PlayOneShot(RandomClip());
        }
        if (Input.GetKeyDown("j") && luck <= 4)
        {
            //Gives the debuff (still needs to be done)
            audioSource.Stop();
            dText.text = "Du siehst schrecklich aus!\nGeh ein bisschen mehr Trainieren!\nDu hast Muskelmasse verloren...\n\nBye!";
            audioSource.clip = audioClipArray[3];
            audioSource.Play();
            exitScene = true;
        }
        if (Input.GetKeyDown("j") && luck >= 6)
        {
            audioSource.Stop();
            dText.text = "Du siehst erstaunlich breit aus!\nGönn dir eine Pause!\nDu hast Muskelmasse aufgebaut...\n\nBye!";
            //Adds Item to the inventory
            SaveGame.AddItemToInventory(SwagFlyHighs);
            audioSource.clip = audioClipArray[4];
            audioSource.Play();
            exitScene = true;
        }
        if (Input.GetKeyDown("n"))
        {
            audioSource.Stop();
            dText.text = "Ok, schönen Tag noch!";
            audioSource.PlayOneShot(RandomClip());
            exitScene = true;
        }
    }

    private void OnDestroy()
    {
        //Saves the new inventory when the scene finishes
        SaveGame.SavePlayer();
    }

    AudioClip RandomClip()
    {
        //Chooses a random audioclip of an array
        int attempts = 3;
        AudioClip newClip = audioClipArray[Random.Range(0, audioClipArray.Length - 2)];
        while (newClip == lastClip && attempts > 0)
        {
            newClip = audioClipArray[Random.Range(0, audioClipArray.Length - 2)];
            attempts--;
        }
        lastClip = newClip;
        return newClip;
    }
}
