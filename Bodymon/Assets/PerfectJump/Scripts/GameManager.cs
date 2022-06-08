using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; set; }

    public UIManager uIManager;
    public ScoreManager scoreManager;
    public GameObject player;
    public Rigidbody2D playerRigidbody2D;
    public GameObject obstaclePrefab;
    public Camera cam;
    public Animator perfectAnimator;

    [Header("Game settings")]
    [Space(5)]
    public float minYObstaclePosition = -4f;
    [Space(5)]
    public float maxYObstaclePosition = 2f;
    [Space(5)]
    public Color[] obstacleColors;

    readonly float xDistanceBetweenObstacles = 2.5f; //fixed because of first jump, if you change this then you need to change jump force too
    GameObject lastObstacle;
    GameObject newObstacle;
    Vector3 screenSize;
    int obstacleIndex;

    public bool inAir;

    void Awake()
    {
        //DontDestroyOnLoad(this);

        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    public void Leave(float gainsMultiplier)
    {
        MinigameSave.GainsMultiplier = gainsMultiplier;
        MinigameSave.stillOpen = true;
        Debug.Log(MinigameSave.lastPlayerPosition);
        SceneManager.LoadScene(2, LoadSceneMode.Single);
    }

    // Start is called before the first frame update
    void Start()
    {
        screenSize = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0));
        //Debug.Log(screenSize);

        Physics2D.gravity = new Vector2(0, -9.81f);
        Application.targetFrameRate = 60;
        CreateScene();
    }

    void Update()
    {
        if (uIManager.gameState == GameState.PLAYING)
        {
            if (Input.GetMouseButtonDown(0))
            {
                if (uIManager.IsButton())
                    return;

                if (!inAir)
                {
                    playerRigidbody2D.velocity = Vector2.zero;
                    playerRigidbody2D.AddForce(new Vector2(95, 440));
                    inAir = true;
                }
            }

            if (lastObstacle.transform.position.x < cam.transform.position.x + (2 * screenSize.x))
                CreateNewObstacle();
        }
    }

    //create new scene
    public void CreateScene()
    { 
        obstacleIndex = 0;
        //reset camera position
        cam.transform.position = new Vector3(0, 0, -10);

        //first obstacle
        lastObstacle = Instantiate(obstaclePrefab);
        lastObstacle.transform.position = new Vector2(-1.5f, -1.5f);
        lastObstacle.GetComponent<SpriteRenderer>().color = GetRandomColor();
        lastObstacle.GetComponent<Obstacle>().index = obstacleIndex;

        //player on the first obstacle
        player.transform.position = new Vector2(-1.5f, -.8f);
        player.transform.rotation = new Quaternion(0,0,0,0);
        playerRigidbody2D.bodyType = RigidbodyType2D.Dynamic;
        player.GetComponent<SpriteRenderer>().enabled = true;
        player.GetComponent<TrailRenderer>().enabled = true;
        playerRigidbody2D.gravityScale = 3f;

        obstacleIndex++;

        //second obstacle
        lastObstacle = Instantiate(obstaclePrefab);
        lastObstacle.transform.position = new Vector2(1f, -.5f);
        lastObstacle.GetComponent<SpriteRenderer>().color = GetRandomColor();
        lastObstacle.GetComponent<Obstacle>().index = obstacleIndex;

        //third obstacle
        CreateNewObstacle();
    }

    //create obstacle
    public void CreateNewObstacle()
    {
        obstacleIndex++;

        //random y position, depend on previous obstacle
        float newObstacleY = UnityEngine.Random.Range(lastObstacle.transform.position.y - 1.25f, lastObstacle.transform.position.y + 1.25f);

        //dont go over the top limit
        if (newObstacleY > maxYObstaclePosition)
            newObstacleY = maxYObstaclePosition;

        //dont go bellow the bottom limit
        if (newObstacleY < minYObstaclePosition)
            newObstacleY = minYObstaclePosition;

        //create obstacle
        newObstacle = Instantiate(obstaclePrefab);
        newObstacle.transform.position = new Vector2(lastObstacle.transform.position.x + xDistanceBetweenObstacles, newObstacleY);
        newObstacle.GetComponent<SpriteRenderer>().color = GetRandomColor();
        newObstacle.GetComponent<Obstacle>().index = obstacleIndex;
        lastObstacle = newObstacle;
    }

    //restart game, reset score
    public void RestartGame()
    {
        if (uIManager.gameState == GameState.PAUSED)
            Time.timeScale = 1;

        cam.transform.position = new Vector3(0,0,-10);
        scoreManager.ResetCurrentScore();
        ClearScene();
        CreateScene();
        uIManager.ShowGameplay();
        inAir = false;
        AudioManager.Instance.PlayMusic(AudioManager.Instance.gameMusic);
    }


    //clear all obstacles from scene
    public void ClearScene()
    {
        GameObject[] obstacles = GameObject.FindGameObjectsWithTag("Obstacle");

        foreach (GameObject item in obstacles)
        {
            Destroy(item);
        }
    }

    public void PlayPerfect()
    {
        perfectAnimator.Play("Show");
    }

    Color GetRandomColor()
    {
        return obstacleColors[UnityEngine.Random.Range(0, obstacleColors.Length)];
    }

    //show game over gui
    public void GameOver()
    {
        if (uIManager.gameState == GameState.PLAYING)
        {
            AudioManager.Instance.PlayEffects(AudioManager.Instance.gameOver);
            uIManager.ShowGameOver();
            scoreManager.UpdateScoreGameover();
            Debug.Log(scoreManager.currentScoreLabel.text);
            Leave(Int32.Parse(scoreManager.currentScoreLabel.text)/15f);
        }
    }
}
