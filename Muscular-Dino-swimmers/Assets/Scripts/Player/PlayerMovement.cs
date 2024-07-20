using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public float impulseStrength = 1f; // Strength of the impulse for movement
    public float rotationSpeed = 360f; // Speed of rotation
    public float maxSpeed = 5f; // Maximum speed of the player

    private Rigidbody2D rb; // Reference to the Rigidbody2D component

    private void Awake()
    {
        // Get the Rigidbody2D component from the GameObject
        rb = GetComponent<Rigidbody2D>();
        if (rb == null)
        {
            // Log an error if Rigidbody2D is not found
            Debug.LogError("Rigidbody2D component not found on the GameObject.");
        }
    }

    private void FixedUpdate()
    {
        // Limit the player's speed in every FixedUpdate call
        LimitSpeed();
    }

    private void LimitSpeed()
    {
        // Check if the current speed exceeds the maximum speed
        if (rb.velocity.magnitude > maxSpeed)
        {
            // Scale the velocity to limit the speed to the maximum speed
            rb.velocity = rb.velocity.normalized * maxSpeed;
        }
    }

    public void OnMovement(InputAction.CallbackContext context)
    {
        // Log when movement input is received
        Debug.Log("Movement input received");
        // Read the movement vector, normalize it, and apply an impulse
        Vector2 movementInput = context.ReadValue<Vector2>().normalized;
        if (movementInput != Vector2.zero)
        {
            // Apply an impulse force to move the player
            rb.AddForce(movementInput * impulseStrength, ForceMode2D.Impulse);
        }
    }

    public void OnLook(InputAction.CallbackContext context)
    {
        // Determine the control scheme (gamepad or mouse) and rotate accordingly
        if (Gamepad.current != null && context.control.device == Gamepad.current)
        {
            // Read the look input from the gamepad
            Vector2 lookInput = context.ReadValue<Vector2>();
            RotateTowardsDirection(lookInput);
        }
        else if (Mouse.current != null && context.control.device == Mouse.current)
        {
            // Convert mouse position to world space and calculate direction
            Vector2 mouseScreenPosition = Mouse.current.position.ReadValue();
            Vector2 mouseWorldPosition = Camera.main.ScreenToWorldPoint(mouseScreenPosition);
            Vector2 direction = (mouseWorldPosition - (Vector2)transform.position).normalized;
            RotateTowardsDirection(direction);
        }
    }

    private void RotateTowardsDirection(Vector2 direction)
    {
        // Rotate the player towards the given direction
        if (direction != Vector2.zero)
        {
            // Calculate the target angle and smoothly rotate towards it
            var targetAngle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90f;
            var angle = Mathf.MoveTowardsAngle(rb.rotation, targetAngle, rotationSpeed * Time.fixedDeltaTime);
            rb.rotation = angle;
        }
    }
}