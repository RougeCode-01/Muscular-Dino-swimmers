using System;
using UnityEngine;
public class Lightning : MonoBehaviour
{
    [SerializeField] private GameObject LightningSprite;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            DamagePlayer();
        }
    }
    
    private void DamagePlayer()
    {
        //Damage player using health manager
        Debug.Log("Youve been hit by lightning");
    }
    
    //once this game object is activated, it will change the alpha of the sprite to make it flicker
    private void FlikkerLightning()
    {
        //change the alpha of the sprite to make it flicker
        Debug.Log("Lightning is flickering");
    }
    
}