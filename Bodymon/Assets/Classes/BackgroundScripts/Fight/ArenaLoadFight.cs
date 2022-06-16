using UnityEngine;
using UnityEngine.SceneManagement;

public class ArenaLoadFight : MonoBehaviour
{
    //if in arena range -> true
    private bool inRange;

    // Start is called before the first frame update
    private void Start()
    {
    }

    // Update is called once per frame
    private void Update()
    {
        if (inRange && Input.GetButtonDown("Interact"))
        {
            SceneManager.LoadScene(5, LoadSceneMode.Single);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        inRange = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        inRange = true;
    }
}