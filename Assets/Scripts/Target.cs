using UnityEngine;

public class Target : MonoBehaviour
{
    [SerializeField] private int pointValue;
    [SerializeField] private ParticleSystem explosion;

    private GameManager gameManager;
    private Rigidbody targetRb;

    private float minSpeed = 12f;
    private float maxSpeed = 16f;
    private float maxTorque = 10f;
    private float xRange = 4f;
    private float ySpawnPos;

    private void Awake()
    {
        gameManager = FindObjectOfType<GameManager>();
        targetRb = GetComponent<Rigidbody>();
    }

    private void Start()
    {
        targetRb.AddForce(RandomForce(), ForceMode.Impulse);
        targetRb.AddTorque(RandomTorque(), RandomTorque(), RandomTorque(), ForceMode.Impulse);
        transform.position = RandomSpawnPos();
    }

    private void OnMouseEnter()
    {
        if (gameManager.IsGameActive && Input.GetMouseButton(0))
        {
            gameManager.UpdateScore(pointValue);
            Instantiate(explosion, transform.position, explosion.transform.rotation);
            Destroy(gameObject);
        }
    }

    // Generate a random force within the given range
    private Vector3 RandomForce()
    {
        return Vector3.up * Random.Range(minSpeed, maxSpeed);
    }

    // Generate a random torque within the given range
    private float RandomTorque()
    {
        return Random.Range(-maxTorque, maxTorque);
    }

    // Generate a random spawn position
    private Vector3 RandomSpawnPos()
    {
        return new Vector3(Random.Range(-xRange, xRange), -ySpawnPos);
    }
}
