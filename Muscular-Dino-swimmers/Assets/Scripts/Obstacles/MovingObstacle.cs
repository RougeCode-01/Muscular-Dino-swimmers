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
        // This works but isn't scalable, if you rotate the object to create one that moves up and down, it breaks the entire script.
        // In the future, please consider a more scalable option such as PointA and PointB, or something simpler like a DOTWEEN based on movement distance? -C
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
//     private void OnCollisionEnter2D(Collider2D other)
//     {
// // Please do not destroy the player. - C
//     }

}