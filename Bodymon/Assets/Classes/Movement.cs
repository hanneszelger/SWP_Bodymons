using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    float horizontal;
    float vertical;

    private Vector2 camPosition;
    Vector2 position;

    Vector2 camLimit;
    bool moved;

    private float height;
    private float width;

    private Vector2 move;
    private Rigidbody2D body;

    public Camera camera;
    public float speed = 150.0f;

    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody2D>();

        height = camera.orthographicSize;
        width = height * camera.aspect;
    }

    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");

        move = new Vector2(speed * horizontal, speed * vertical);
        position = camera.transform.position;

        camLimit = new Vector2(width - 3, height -3);
        //camPosition = camera.transform.position;
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        if ((body.position.x + move.x * Time.deltaTime > position.x + camLimit.x && horizontal == 1) || (body.position.x - move.x * Time.deltaTime < position.x - camLimit.x && horizontal == -1))
        {
            camera.transform.position = Vector3.Lerp(camera.transform.position, new Vector3(position.x + move.x * Time.deltaTime, position.y, -10), 30);
            moved = true;
        }

        if ((body.position.y + move.y * Time.deltaTime > position.y + camLimit.y && vertical == 1) || (body.position.y - move.y * Time.deltaTime < position.y - camLimit.y && vertical == -1))
        {
            camera.transform.position = Vector3.Lerp(camera.transform.position, new Vector3(position.x, position.y + move.y * Time.deltaTime, -10), 30);
            moved = true;
        }

        if (!moved)
        {
            body.velocity = move;
        }
        moved = false;

    }
}
