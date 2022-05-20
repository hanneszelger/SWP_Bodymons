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
            dText.text = "Willst du so richtig schnell so richtig breit werden?\nWenn ja würde ich dir Trenbalone empfehlen, was\ndich 100 Coins kosten würde. (J/N)";
        }
        if (Input.GetKeyDown("j"))
        {
            dText.text = "Gute Entscheidung!...\n\nBye!";
            exitScene = true;
        }
        if (Input.GetKeyDown("n"))
        {
            dText.text = "Ok, looser schönen Tag noch!";
            SceneManager.LoadScene(0, LoadSceneMode.Single);
        }
    }
}
