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

    public float speed;

    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        camRigid = Camera.main.GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");
        move = new Vector2(speed * horizontal, speed * vertical);
    }

    
    private void FixedUpdate()
    {
        body.velocity = move;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "left" || collision.tag == "right")
        {
            camRigid.velocity = new Vector2(move.x, camRigid.velocity.y);
        }

        if (collision.tag == "bottom" || collision.tag == "top")
        {
            camRigid.velocity = new Vector2(camRigid.velocity.x, move.y);
        }

    }
}
