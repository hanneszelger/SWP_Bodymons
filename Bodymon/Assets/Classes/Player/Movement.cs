using UnityEngine;

public class Movement : MonoBehaviour
{
    private float horizontal;
    private float vertical;

    private Camera cam;
    private Rigidbody2D camRigid;
    private float camWidth;
    private float camHeight;

    private Vector2 move;
    private Rigidbody2D body;

    //public allows to edit its value in Unity
    public float speed;

    private void Start()
    {
        cam = Camera.main;
        camHeight = cam.orthographicSize;
        camWidth = camHeight * 2;
        //gets the player and main cam object as Rigidbody2D
        body = GetComponent<Rigidbody2D>();
        camRigid = cam.GetComponent<Rigidbody2D>();
    }

    private void Update()
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

        if ((cam.transform.position.x + camWidth - 2 < body.position.x + (body.velocity.x * Time.fixedDeltaTime) && body.velocity.x > 0) ||
            (cam.transform.position.x - camWidth + 2 > body.position.x + (body.velocity.x * Time.fixedDeltaTime) && body.velocity.x < 0))
        {
            camRigid.velocity = new Vector2(body.velocity.x, camRigid.velocity.y);
        }
        if ((cam.transform.position.y + camHeight - 2 < body.position.y + (body.velocity.y * Time.fixedDeltaTime) && body.velocity.y > 0) ||
            (cam.transform.position.y - camHeight + 2 > body.position.y + (body.velocity.y * Time.fixedDeltaTime) && body.velocity.y < 0))
        {
            camRigid.velocity = new Vector2(camRigid.velocity.x, body.velocity.y);
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
    }
}