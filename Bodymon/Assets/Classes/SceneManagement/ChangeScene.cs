using System.Collections;
using System.Collections.Generic;
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
        print("Trigger Entered");

        // Could use other.GetComponent<Player>() to see if the game object has a Player component
        // Tags work too. Maybe some players have different script components?
        if (other.tag == "Player")
        {
            int old = SceneManager.GetActiveScene().buildIndex;
            // Player entered, so move level
            SceneManager.LoadScene(sceneBuildIndex, LoadSceneMode.Single);
            print("Switching Scene to " + sceneBuildIndex);
            
            //if (startingPosition.ContainsKey(sceneBuildIndex)) player.position = startingPosition[sceneBuildIndex];
            switch (old)
            {
                case 0:
                    break;
                case 4:
                    GameObject gameObject_player = GameObject.FindWithTag("Player");
                    gameObject_player.transform.position = new Vector3(-13.77f, 18.6f, -2);
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