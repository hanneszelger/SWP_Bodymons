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
        audioSource.PlayOneShot(RandomClip());
    }

    // Update is called once per frame
    void Update()
    {
        int luck = Random.Range(1, 10);
        if (dialogActive && Input.GetKeyDown(KeyCode.Space) && exitScene)
        {
            SceneManager.LoadScene(0, LoadSceneMode.Single);
        }
        if (dialogActive && Input.GetKeyDown(KeyCode.Space) && !exitScene)
        {
            audioSource.Stop();
            dText.text = "Willst du wissen wie es dir geht? (J/N)";
            audioSource.PlayOneShot(RandomClip());
        }
        if (Input.GetKeyDown("j") && luck <= 4)
        {
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
        SaveGame.SavePlayer();
    }

    AudioClip RandomClip()
    {
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
