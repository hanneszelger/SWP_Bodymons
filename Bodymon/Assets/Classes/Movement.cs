using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    float horizontal;
    float vertical;
    private Vector2 move;
    private Rigidbody2D body;

    public float speed = 10.0f;

    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody2D>();

    }

    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");

        Debug.Log(horizontal + ";" + vertical);

        move = new Vector2(speed * horizontal, speed * vertical);
        
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        body.velocity = move;


        //if (Input.GetKeyDown(KeyCode.W))
        //{
        //    body.velocity = new Vector2(horizontal, vertical * speed);
        //    Debug.Log("W");
        //}

        //if (Input.GetKeyDown(KeyCode.A))
        //{
        //    body.velocity = new Vector2(horizontal - speed, vertical);
        //    Debug.Log("A");
        //}

        //if (Input.GetKeyDown(KeyCode.S))
        //{
        //    body.velocity = new Vector2(horizontal, vertical - speed);
        //    Debug.Log("S");
        //}

        //if (Input.GetKeyDown(KeyCode.D))
        //{
        //    body.velocity = new Vector2(horizontal/speed, vertical);
        //    Debug.Log("D");
        //}
    }
}
