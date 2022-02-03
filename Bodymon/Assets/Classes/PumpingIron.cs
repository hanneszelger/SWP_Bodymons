using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PumpingIron : MonoBehaviour
{
    private GameObject gameObject;
    bool inRange;
    Bodymons player;


    // Start is called before the first frame update
    void Start()
    {
        gameObject = GameObject.FindWithTag("Player");
        player = gameObject.GetComponent<Bodymons>();
        Debug.Log(gameObject.name);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetAxis("Interact") == 1 && inRange)
        {
            switch (gameObject.tag)
            {
                case "bench":

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
    }
}
