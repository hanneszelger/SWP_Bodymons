using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    float horizontal;
    float vertical;

    private Rigidbody2D camRigid;

    private Vector2 move;
    private Rigidbody2D body;

    //public allows to edit its value in Unity
    public float speed;

    void Start()
    {
        //gets the player and main camera object as Rigidbody2D
        body = GetComponent<Rigidbody2D>();
        camRigid = Camera.main.GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        //Left/A = -1, none = 0, Right/D = 1
        horizontal = Input.GetAxisRaw("Horizontal");

        //Up/W = -1, none = 0, Down/S = 1
        vertical = Input.GetAxisRaw("Vertical");

        //Combines user input and speed to a Vector2
        move = new Vector2(speed * horizontal, speed * vertical);
    }

    
    private void FixedUpdate()
    {
        //Moves the player
        body.velocity = move;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        //Checks the collision tag and adjusts the camera accordingly
        if ((collision.tag == "left" && horizontal == -1) || (collision.tag == "right" && horizontal == 1))
        {
            camRigid.velocity = new Vector2(move.x, camRigid.velocity.y);
        }

        if ((collision.tag == "bottom" && vertical == -1) || (collision.tag == "top" && vertical == 1))
        {
            camRigid.velocity = new Vector2(camRigid.velocity.x, move.y);
        }
    }
}
