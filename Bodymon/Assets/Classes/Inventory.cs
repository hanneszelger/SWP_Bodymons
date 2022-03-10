using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public bool[] isFull;
    public GameObject[] slots;
    private SpriteRenderer sr;
    // Start is called before the first frame update
    void Start()
    {
        sr = gameObject.GetComponent<SpriteRenderer>();
        sr.enabled = false;
       
    }

    // Update is called once per frame
    void Update()
    {
        //if (Input.GetAxis("Inventory1") == 1)
        //{

        //}
        //if (Input.GetAxis("Inventory2") == 1)
        //{

        //}
        //if (Input.GetAxis("Inventory3") == 1)
        //{

        //}
        if (Input.GetKeyDown(KeyCode.R))
        {
            sr.enabled = !sr.enabled;
        }
    }
}
