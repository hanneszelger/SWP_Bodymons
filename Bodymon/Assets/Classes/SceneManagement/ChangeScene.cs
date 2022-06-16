using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    public int sceneBuildIndex;
    public Transform player;

    // Level move zoned enter, if collider is a player
    // Move game to another scene
    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Trigger Entered");

        // Could use other.GetComponent<Player>() to see if the game object has a Player component
        // Tags work too. Maybe some players have different script components?
        if (other.gameObject.tag == "Player")
        {
            int old = SceneManager.GetActiveScene().buildIndex;
            // Player entered, so move level
            SceneManager.LoadScene(sceneBuildIndex, LoadSceneMode.Single);

            //if (startingPosition.ContainsKey(sceneBuildIndex)) player.position = startingPosition[sceneBuildIndex];
            switch (SavedPositionManager.lastScene)
            {
                case 0:
                    Debug.Log("Trigger Entered: 0");
                    break;

                case 4:
                    GameObject gameObject_player = GameObject.FindWithTag("Player");
                    gameObject_player.transform.position = new Vector3(-13.77f, 18.6f, -2);
                    Debug.Log("Trigger Entered: 4");
                    break;

                case 6:
                    GameObject gameObject_player1 = GameObject.FindWithTag("Player");
                    gameObject_player1.transform.position = new Vector3(-6f, 40.6f, -2);
                    Debug.Log("Trigger Entered: 6");
                    break;

                default:
                    break;
            }
        }
    }
}

public class ScenePoint
{
    public Vector3 spawnpoint;
    public int sceneBuildIndex;

    public ScenePoint(Vector3 _spawnpoint, int _sceneBuildIndex)
    {
        spawnpoint = _spawnpoint;
        sceneBuildIndex = _sceneBuildIndex;
    }
}

public static class SavePosition
{
    public static Vector3 position;
}