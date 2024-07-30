using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CurrentEffect : MonoBehaviour
{
    
        public float force= -5f; // Magnitude of the force
        public float interval = 5f; // Time interval between the current

        private bool isPlayerInCollider = false;
        private Coroutine currentCoroutine;

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Player"))
            {
            Debug.Log("Player is in Contact");

            if (!isPlayerInCollider)
                {
                    isPlayerInCollider = true;
                    currentCoroutine = StartCoroutine(ApplyForce(other.GetComponent<Rigidbody2D>()));
                }
            }
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            if (other.CompareTag("Player"))
            {
                Debug.Log("Player Exited");
                if (isPlayerInCollider)
                {
                    isPlayerInCollider = false;
                    StopCoroutine(currentCoroutine);
                }
            }
        }

        private IEnumerator ApplyForce(Rigidbody2D rb)
        {
            while (isPlayerInCollider)
            {
                if (rb != null)
                {

                    Vector2 direction =  (Vector2)transform.position * new Vector2(0,1);

                    rb.AddForce(direction * force, ForceMode2D.Impulse);
                }

                yield return new WaitForSeconds(interval);

            }
        }
    }

        
    /*

    public float pushForce = 5f; // Adjust the force as needed

    private void OnTriggerStay2D(Collider2D other)
    {
        // Check if the player is inside the collider
        if (other.CompareTag("Player"))
        {
            // Get the player's Rigidbody2D component
            Rigidbody2D playerRb = other.GetComponent<Rigidbody2D>();
            if (playerRb != null)
            {
                // Apply an upward force to the player
                playerRb.AddForce(Vector2.up * pushForce);
            }
        }
    }
}*/