using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    float horizontal;
    float vertical;

    private Camera camera;
    private Rigidbody2D camRigid;
    float camWidth;
    float camHeight;

    private Vector2 move;
    private Rigidbody2D body;

    //public allows to edit its value in Unity
    public float speed;

    void Start()
    {
        camera = Camera.main;
        camHeight = camera.orthographicSize;
        camWidth = camHeight * 2;
        Debug.Log(camHeight +";" + camWidth + ";" + camera.transform.position.x);
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
        camRigid.velocity = new Vector2(0, 0);
        body.velocity = move;
        //Checks the collision tag and adjusts the camera accordingly
        Debug.Log(camera.transform.position.x + camWidth - 1 + ";" + body.position.x + (body.velocity.x * Time.fixedDeltaTime) + ";" + body.position.x +";"+ body.velocity.x * Time.fixedDeltaTime);
        if ((camera.transform.position.x + camWidth - 2 < body.position.x + (body.velocity.x * Time.fixedDeltaTime) && body.velocity.x > 0) || 
            (camera.transform.position.x - camWidth + 2 > body.position.x + (body.velocity.x * Time.fixedDeltaTime) && body.velocity.x < 0))
        {
            camRigid.velocity = new Vector2(body.velocity.x, camRigid.velocity.y);
        }
        if ((camera.transform.position.y + camHeight - 2 < body.position.y + (body.velocity.y * Time.fixedDeltaTime) && body.velocity.y > 0) ||
            (camera.transform.position.y - camHeight + 2 > body.position.y + (body.velocity.y * Time.fixedDeltaTime) && body.velocity.y < 0))
        {
            camRigid.velocity = new Vector2(camRigid.velocity.x, body.velocity.y);
        }

        //komplett rechts
        //if (camera.transform.position.x + camWidth < body.position.x)
        //{
        //    camRigid.velocity = new Vector2(body.velocity.x, camRigid.velocity.y);
        //}
        //if ()
        //{
        //    camRigid.velocity = new Vector2(camRigid.velocity.x, move.y);
        //}
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
       
    }
}
