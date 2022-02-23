using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GymInside : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        int reps = 12;


        float temp = 100 / (1 + 500 * Mathf.Pow(0.4f, reps));
        Debug.Log(temp);
    }

    // Update is called once per frame
    void Update()
    {
      
    }




    void OnCollisionStay(Collision collisioninfo)
    {
        if (collisioninfo.gameObject.name == "Player" && Input.GetKeyDown(KeyCode.E))
        {
            MuscleSet ms = new MuscleSet();
            //ms.Chest += 1;
            //ms.Lat += 0.1;

            int reps = 12;

            //12 reps = 99% gains
            float temp = 100 / (1 + 500 * Mathf.Pow(0.4f, reps));
            Debug.Log(temp);
        }
    }
}
