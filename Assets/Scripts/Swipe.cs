using UnityEngine;

public class Swipe : MonoBehaviour
{
    private TrailRenderer trailRenderer;
    [SerializeField] private Camera mainCamera;

    void Start()
    {
        trailRenderer = GetComponent<TrailRenderer>();
        mainCamera = Camera.main;
        trailRenderer.emitting = false;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            trailRenderer.emitting = true;
        }

        if (Input.GetMouseButton(0))
        {
            Vector3 mousePosition = Input.mousePosition;
            mousePosition.z = mainCamera.transform.position.z;
            Vector3 worldPosition = mainCamera.ScreenToWorldPoint(mousePosition);
            worldPosition.z = 0;
            transform.position = new Vector3(worldPosition.x, worldPosition.y, transform.position.z);
        }

        if (Input.GetMouseButtonUp(0))
        {
            trailRenderer.emitting = false;
        }
    }
}