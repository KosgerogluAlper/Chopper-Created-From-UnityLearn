using UnityEngine;

public class Sensor : MonoBehaviour
{
    private GameManager gameManager;
    private int liveCount = 3;

    private void Awake()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!other.gameObject.CompareTag("Bad") && liveCount <= 0)
        {
            gameManager.GameOver();
        }
        else if (!other.gameObject.CompareTag("Bad"))
        {
            Destroy(other.gameObject);
            liveCount--;
            gameManager.LiveTextUI(liveCount);
        }
    }
}