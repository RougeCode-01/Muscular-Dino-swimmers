using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public float impulseStrength = 10f; // Adjust the strength of the impulse for movement
    public float rotationSpeed = 360f; // Degrees per second for rotation

    private Rigidbody2D rb; // Reference to the Rigidbody2D component
    private PlayerInputs playerInputs; // Reference to the PlayerInputs object
    private Vector2 movementInput; // Vector2 to store the movement input
    private Vector2 lookInput; // Vector2 to store the look input

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        playerInputs = new PlayerInputs();

        // Subscribe to the movement and look actions
        playerInputs.Player.Movement.performed += ctx => movementInput = ctx.ReadValue<Vector2>().normalized; // Normalize input
        playerInputs.Player.Movement.canceled += ctx => movementInput = Vector2.zero;
        playerInputs.Player.Look.performed += ctx => lookInput = ctx.ReadValue<Vector2>();
        playerInputs.Player.Look.canceled += ctx => lookInput = Vector2.zero;
    }

    private void OnEnable()
    {
        // Enable player inputs
        playerInputs.Enable();
    }

    private void OnDisable()
    {
        // Disable player inputs
        playerInputs.Disable();
    }

    private void FixedUpdate()
    {
        // Apply movement
        if (movementInput != Vector2.zero)
        {
            rb.AddForce(movementInput * impulseStrength, ForceMode2D.Impulse);
        }

        // Apply rotation
        if (lookInput != Vector2.zero)
        {
            var targetAngle = Mathf.Atan2(lookInput.y, lookInput.x) * Mathf.Rad2Deg - 90f; // Adjust for sprite orientation
            var angle = Mathf.MoveTowardsAngle(rb.rotation, targetAngle, rotationSpeed * Time.fixedDeltaTime);
            rb.rotation = angle;
        }
    }
}