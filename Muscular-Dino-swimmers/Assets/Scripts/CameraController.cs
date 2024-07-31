using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private float padding = 2.0f; // Padding around the players
    [SerializeField] private float minSize = 5.0f; // Minimum orthographic size of the camera

    private Camera cam;

    private void Start()
    {
        // Get the Camera component attached to this GameObject
        cam = GetComponent<Camera>();
    }

    private void Update()
    {
        // Find all GameObjects with the tag "Player"
        GameObject[] players = GameObject.FindGameObjectsWithTag("Player");
        if (players.Length == 0)
            return;

        // Initialize the bounds with the position of the first player
        Vector3 averagePosition = Vector3.zero;
        Bounds bounds = new Bounds(players[0].transform.position, Vector3.zero);

        // Encapsulate all player positions within the bounds
        foreach (GameObject player in players)
        {
            bounds.Encapsulate(player.transform.position);
        }

        // Calculate the average position of all players
        averagePosition = bounds.center;
        // Set the camera position to the average position of all players
        cam.transform.position = new Vector3(averagePosition.x, averagePosition.y, cam.transform.position.z);

        // Calculate the required orthographic size to fit all players within the camera view
        float size = Mathf.Max(bounds.size.x, bounds.size.y) / 2 + padding;
        // Set the camera orthographic size, ensuring it is not smaller than the minimum size
        cam.orthographicSize = Mathf.Max(size, minSize);
    }
}