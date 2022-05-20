using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DialogueManager : MonoBehaviour
{

    public GameObject dBox;
    public Text dText;

    public bool dialogActive;
    public bool exitScene = false;

    // Start is called before the first frame update
    void Start()
    {
        
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
            dText.text = "Willst du wissen wie es dir geht? (J/N)";
        }
        if (Input.GetKeyDown("j") && luck <= 4)
        {
            dText.text = "Du siehst schrecklich aus!\nGeh ein bisschen mehr Trainieren!\nDu hast Muskelmasse verloren...\n\nBye!";
            exitScene = true;
        }
        if (Input.GetKeyDown("j") && luck >= 6)
        {
            dText.text = "Du siehst erstaunlich breit aus!\nGönn dir eine Pause!\nDu hast Muskelmasse aufgebaut...\n\nBye!";
            exitScene = true;
        }
        if (Input.GetKeyDown("n"))
        {
            dText.text = "Ok, schönen Tag noch!";
            SceneManager.LoadScene(0, LoadSceneMode.Single);
        }
    }
}
