using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingObstacle : MonoBehaviour
{
    // Start is called before the first frame update

    public float speed = 3.0f; // Speed of the obstacle
    public float moveDistance = 5.0f; // Distance the obstacle moves back and forth

    private Vector3 startPosition;
    private bool movingRight = true;

    void Start()
    {
        startPosition = transform.position;
    }

    void Update()
    {
        // Calculate movement
        float movement = speed * Time.deltaTime;
        if (movingRight)
        {
            transform.Translate(movement, 0, 0);
            if (transform.position.x >= startPosition.x + moveDistance)
                movingRight = false;
        }
        else
        {
            transform.Translate(-movement, 0, 0);
            if (transform.position.x <= startPosition.x - moveDistance)
                movingRight = true;
        }
    }
    private void OnCollisionEnter2D(Collider2D other)
    {

        if (other.CompareTag("Player"))
        {
            Destroy(other.gameObject); // Destroy the player on collision
        }
    }

}