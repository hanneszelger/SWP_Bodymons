using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PumpingIron : MonoBehaviour
{
    private GameObject gameObject_player;
    private GameObject gameObject_gymSpawn;
    bool inRange;
    Bodymon player;


    // Start is called before the first frame update
    void Start()
    {
        gameObject_player = GameObject.FindWithTag("Player");
        player = gameObject_player.GetComponent<Bodymon>();
        gameObject_gymSpawn = GameObject.FindWithTag("GymSpawn");
        //Debug.Log(gameObject_player.name);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Interact") && inRange)
        {
            switch (gameObject.tag)
            {
                case "bench":
                    BenchPress();
                    break;
                case "SquatRack":
                    //ToDo: squat method
                    break;
            }
        }
    }

    void OnTriggerEnter2D(Collider2D playerCollider)
    {
        if (playerCollider.CompareTag("Player"))
        {
            inRange = true;
        }
    }

    void OnTriggerExit2D(Collider2D playerCollider)
    {
        if (playerCollider.CompareTag("Player"))
        {
            inRange = false;
        }
    }

    void BenchPress()
    {
        //Calculate with sinus fucntion
        //float weight = player.Muscles.Chest / player.Muscles.MaxValue * 355 / 80 %;
        //10-> 10 %; 355kg-> 80 % -> 12 wdh
        //player.Muscles.Chest / player.Muscles.MaxValue * 355 / 80 % = 12 wdh
        //player.Muscles.Chest +=

        player.Muscles.Chest += 1;
        Debug.Log(player.Muscles.Chest);

        gameObject_player.transform.position = gameObject_gymSpawn.transform.position;


    }
}
