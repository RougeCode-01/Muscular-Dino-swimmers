using UnityEngine;
using UnityEngine.InputSystem;

public class CrosshairController : MonoBehaviour
{
    private Camera mainCamera;// Reference to the main camera
    private Vector3 targetPosition;// Vector3 to store the target position
    private PlayerInputs playerInputs;// Reference to the PlayerInputs object
    public Transform playerTransform;// Reference to the player's transform
    public float someMultiplier = 1f;// Multiplier for the right stick input

    void Awake()
    {
        mainCamera = Camera.main;// Get the main camera
        Cursor.visible = false; // Hide the system cursor
        playerInputs = new PlayerInputs(); // Initialize playerInputs
    }

    void OnEnable()
    {
        // Enable player inputs
        playerInputs.Enable(); 
    }

    void OnDisable()
    {
        // Disable player inputs
        playerInputs.Disable(); 
    }

    void Update()
    {
        // Detect input source
        Vector2 rightStickInput = playerInputs.Player.Look.ReadValue<Vector2>();
        bool isUsingController = rightStickInput.magnitude > 0.1f; // Check if the right stick input is greater than 0.1f

        if (isUsingController)
        {
            // For right stick input
            targetPosition = playerTransform.position + new Vector3(rightStickInput.x, rightStickInput.y, 0) * someMultiplier;
        }
        else
        {
            // For mouse input
            Vector3 mousePosition = Input.mousePosition;
            mousePosition.z = 10.0f; // Distance from the camera
            targetPosition = mainCamera.ScreenToWorldPoint(mousePosition);
            targetPosition.z = 0; // Keep the z position at 0
        }

        transform.position = targetPosition;
    }
}