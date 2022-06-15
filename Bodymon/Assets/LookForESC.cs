using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LookForESC : MonoBehaviour
{
    public static bool menuopened = false;
    
    private GameObject playerObject;
    public static Vector3 Vector3;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //If User presses Escape the Menu opens and the position saves
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            playerObject = GameObject.FindWithTag("Player");
            Vector3 = playerObject.transform.position;
            Debug.Log("Got this position: "+Vector3);
            menuopened = true;
            SceneManager.LoadScene(9, LoadSceneMode.Single);
        }
    }
}
