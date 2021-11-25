using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    float horizontal;
    float vertical;

    private Vector2 camPosition;

    private Vector2 move;
    private Rigidbody2D body;

    public Camera camera;
    public float speed = 150.0f;

    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        body.rotation = 0;
    }

    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");

        Debug.Log(horizontal + ";" + vertical);

        move = new Vector2(speed * horizontal, speed * vertical);
        body.rotation =0;
        //camPosition = camera.transform.position;
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        //camera.transform.position = Vector3.Lerp(camera.transform.position, new Vector3(camPosition.x + move.x, camPosition.y + move.y, -10), speed);


        // Ensure the camera always looks at the player
        //transform.LookAt(transform.parent);

        //if ((body.position.x + move.x*Time.deltaTime > 2 || body.position.x - move.x*Time.deltaTime < -2) && move.x != 0)
        //    camera.transform.position = Vector3.Lerp(camera.transform.position, new Vector3(camPosition.x + move.x*Time.deltaTime, camPosition.y, -10), 1);
        //if ((body.position.y + move.y*Time.deltaTime > 2 || body.position.y - move.y*Time.deltaTime < -2) && move.y != 0)
        //        camera.transform.position = Vector3.Lerp(camera.transform.position, new Vector3(camPosition.x, camPosition.y + move.y*Time.deltaTime, -10), 1);
        //else
        //{
                
        //}

        body.velocity = move;
        body.rotation = 0;



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
