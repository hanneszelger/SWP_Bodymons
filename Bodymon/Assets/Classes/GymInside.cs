using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GymInside : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
      
    }




    void OnCollisionStay(Collider2D collisioninfo)
    {
        if (collisioninfo.gameObject.name == "Player" && Input.GetKeyDown(KeyCode.E))
        {
            MuscleSet ms = new MuscleSet();
            ms.Chest += 1;
            ms.Lat += 0.1;
        }
    }
}
