using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class BombScript : MonoBehaviour
{
    [SerializeField] private float defuseTime = 5f;

    public static UnityEvent onBombDefused = new UnityEvent();
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
        player.GetComponent<Animator>().Play("Interact");

        yield return new WaitForSeconds(defuseTime);

        player.Unfreeze();
        onBombDefused?.Invoke();
        Destroy(gameObject);
        StartCoroutine(BombFinished(player));
    }

    private IEnumerator BombFinished(PlayerMovement player)
    {
        player.GetComponent<Animator>().Play("OK");
        yield return new WaitForSeconds(defuseTime / 3);
        player.GetComponent<Animator>().Play("Swim");
    }
}
