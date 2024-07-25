using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float impulseStrength = 1f; // Strength of the impulse for movement
    [SerializeField] private float rotationSpeed = 360f; // Speed of rotation
    [SerializeField] private float maxSpeed = 5f; // Maximum speed of the player
    [SerializeField] private float lookSensitivity = 0.1f; // Adjust this value to control look sensitivity
    [SerializeField] private bool isFrozen = false;
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
        
        // Set the player's color to a random color
        SetColor();
    }

    private void FixedUpdate()
    {
        // Limit the player's speed in every FixedUpdate call
        if (!isFrozen)
        {
            LimitSpeed();
        }
    }
    
    private void SetColor()
    {
        // Get the SpriteRenderer component and set the color of the player
        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
        if (spriteRenderer != null)
        {
            spriteRenderer.color = PlayerManager.GetAndRemoveColor();
        }
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
        if (isFrozen) return;
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
        Vector2 lookInput = context.ReadValue<Vector2>() * lookSensitivity; // Apply sensitivity scaling
        var targetAngle = Mathf.Atan2(lookInput.y, lookInput.x) * Mathf.Rad2Deg - 90f; // Adjust for sprite orientation
        var angle = Mathf.MoveTowardsAngle(rb.rotation, targetAngle, rotationSpeed * Time.fixedDeltaTime);
        rb.rotation = angle;
    }
    public void Freeze()
    {
        isFrozen = true;
        if (rb != null)
        {
            rb.velocity = Vector2.zero;
            rb.angularVelocity = 0f;
        }
    }
    
    public void Unfreeze()
    {
        isFrozen = false;
    }
}