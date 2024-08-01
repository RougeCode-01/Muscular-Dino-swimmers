using UnityEngine;

public class Seaweed : MonoBehaviour
{
    [SerializeField] private GameObject seaweedLightning;
    private Lightning lightning;
    
    
    //if player gets close to the seaweed, seaweed will activate and deal damage to the player
    //how to detect player?
    //use a trigger collider or raycast
    //if player is detected, deal damage to the player after activating the lightning effect
    //the lightning effect is a sprite that will flicker on and off and then turn off after the player is far enough away or no longer on in the trigger collider
    
    private void Awake()
    {
        DeactivateLightning();
    }
    
    private void OnTriggerEnter2D(Collider2D collision)//
    {
        if (collision.CompareTag("Player"))
        {
            ActivateLightning();
            Debug.Log("Player has awaken the seaweed!!!");
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            DeactivateLightning();
            Debug.Log("Player has escaped the seaweed!!!");
        }
    }
    
    private void ActivateLightning()
    {
        seaweedLightning.SetActive(true);
    }
    
    private void DeactivateLightning()
    {
        seaweedLightning.SetActive(false);
    }
}
