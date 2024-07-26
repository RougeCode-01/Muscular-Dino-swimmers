using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CurrentEffect : MonoBehaviour
{

    public float force= 5f; // Magnitude of the force
    public float interval = 2f; // Time interval between force applications

    private bool isPlayerInCollider = false;
    private Coroutine currentCoroutine;

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Player is in Contact");
        if (other.CompareTag("Player"))
        {
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

