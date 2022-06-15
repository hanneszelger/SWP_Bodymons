using UnityEngine;

public class ChildMachine : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D playerCollider)
    {
        // if player collides calls PlayerNowInRange of PumpingIron
        if (playerCollider.CompareTag("Player"))
        {
            transform.parent.GetComponent<PumpingIron>().PlayerNowInRange(gameObject.tag);
        }
        Debug.Log(gameObject.tag);
    }

    public void OnTriggerExit2D(Collider2D playerCollider)
    {
        // if player collides calls PlayerNowOutOfRange of PumpingIron 
        if (playerCollider.CompareTag("Player"))
        {
            transform.parent.GetComponent<PumpingIron>().PlayerNowOutOfRange();
        }
    }
}
