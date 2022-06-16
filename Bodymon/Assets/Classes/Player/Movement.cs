using UnityEngine;
using UnityEngine.SceneManagement;

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

    public Animator animator;

    private void Start()
    {
        if (SceneManager.GetActiveScene().buildIndex == 0)
        {
            //Only change Visibility of Loading-Canvas if it's the main scene
            WaitForThunder.toggleGUI(true);
        }
        cam = Camera.main;
        camHeight = cam.orthographicSize;
        camWidth = camHeight * 2;
        //gets the player and main cam object as Rigidbody2D
        body = GetComponent<Rigidbody2D>();
        camRigid = cam.GetComponent<Rigidbody2D>();

        camRigid.position = transform.position;

        //progressMade.CrossFadeAlpha(0, 0, false);
    }

    private void Update()
    {
        //Left/A = -1, none = 0, Right/D = 1
        horizontal = Input.GetAxisRaw("Horizontal");

        //Up/W = -1, none = 0, Down/S = 1
        vertical = Input.GetAxisRaw("Vertical");

        //Combines user input and speed to a Vector2
        move = new Vector2(speed * horizontal, speed * vertical);

        //Changes the animatorfloat for the coresponding input to get the right animation
        animator.SetFloat("Horizontal", horizontal);
        animator.SetFloat("Vertical", vertical);
        animator.SetFloat("Speed", move.sqrMagnitude);

        try
        {
            if (horizontal != 0 || vertical != 0 || move.sqrMagnitude != 0 && GetComponent<AudioSource>().isPlaying == false)
            {
                //Play footstepsound when player is moving
                GetComponent<AudioSource>().UnPause();
            }
            else
            {
                //Stop footsptepsound when player stopped
                GetComponent<AudioSource>().Pause();
            }
            if (Input.GetKeyDown(KeyCode.B) && SceneManager.GetActiveScene().buildIndex == 0)
            {
                //Recalls to the spawnpoint with a timer and a thunderanimation
                WaitForThunder.toggleGUI(false);
                StartCoroutine(GameObject.Find("Thunder").GetComponent<WaitForThunder>().TimerRoutine());
            }
        }
        catch (System.Exception ex)
        {
            Debug.LogException(ex);
        }
    }

    private void FixedUpdate()
    {
        //Moves the player
        camRigid.velocity = new Vector2(0, 0);
        body.velocity = move;
        //makes sure the camera is Pokemonlike when moving
        if ((cam.transform.position.x + camWidth - 2 < body.position.x + (body.velocity.x * Time.fixedDeltaTime) && body.velocity.x > 0) ||
            (cam.transform.position.x - camWidth + 2 > body.position.x + (body.velocity.x * Time.fixedDeltaTime) && body.velocity.x < 0))
        {
            camRigid.velocity = new Vector2(body.velocity.x, camRigid.velocity.y);
        }
        if ((cam.transform.position.y + camHeight - 1.5 < body.position.y + (body.velocity.y * Time.fixedDeltaTime) && body.velocity.y > 0) ||
            (cam.transform.position.y - camHeight + 1.5 > body.position.y + (body.velocity.y * Time.fixedDeltaTime) && body.velocity.y < 0))
        {
            camRigid.velocity = new Vector2(camRigid.velocity.x, body.velocity.y);
        }
    }
}