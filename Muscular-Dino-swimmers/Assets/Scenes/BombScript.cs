using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class BombScript : MonoBehaviour
{
    [SerializeField] private float defuseTime = 5f;

    public UnityEvent onBombDefused;
    private bool _isBeingDefused = false;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !_isBeingDefused)
        {
            StartCoroutine(DefuseBomb(other.GetComponent<PlayerMovement>()));
        }
        
        if (other.CompareTag("Player") && _isBeingDefused)
        {
            Debug.Log("Bomb is being defused!");
        }
    }

    private IEnumerator DefuseBomb(PlayerMovement player)
    {
        _isBeingDefused = true;
        player.Freeze();

        yield return new WaitForSeconds(defuseTime);

        player.Unfreeze();
        onBombDefused.Invoke();
        Destroy(gameObject);
    }
}
