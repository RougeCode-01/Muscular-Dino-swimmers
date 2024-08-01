using System;
using System.Collections;
using UnityEngine;

public class Lightning : MonoBehaviour
{
    [SerializeField] private float flickerDuration = 0.1f; // Duration of each flicker
    [SerializeField] private float flickerInterval = 0.2f; // Interval between flickers

    private Coroutine flickerCoroutine;
    private SpriteRenderer spriteRenderer;
    public HealthManager healthManager;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        if (spriteRenderer == null)
        {
            Debug.LogError("SpriteRenderer component not found on the GameObject");
        }
    }

    private void OnEnable()
    {
        StartFlicker();
    }

    private void OnDisable()
    {
        StopFlicker();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // Deal damage to the player
            DamagePlayer(other);
        }
    }
    
    private void DamagePlayer(Collider2D player)
    {
        // Deal damage to the player
        HealthManager.Instance.DamagePlayerHM(player.gameObject);
        Debug.Log("Player has been damaged by the lightning!");
    }

    private void StartFlicker()
    {
        if (flickerCoroutine == null)
        {
            flickerCoroutine = StartCoroutine(FlickerLightning());
        }
    }

    private void StopFlicker()
    {
        if (flickerCoroutine != null)
        {
            StopCoroutine(flickerCoroutine);
            flickerCoroutine = null;
            SetAlpha(1f); // Reset alpha to fully visible
        }
    }

    private IEnumerator FlickerLightning()
    {
        while (true)
        {
            SetAlpha(0.5f); // Make the sprite invisible
            yield return new WaitForSeconds(flickerDuration);
            SetAlpha(1f); // Make the sprite visible
            yield return new WaitForSeconds(flickerInterval);
        }
    }

    private void SetAlpha(float alpha)
    {
        if (spriteRenderer != null)
        {
            Color color = spriteRenderer.color;
            color.a = alpha;
            spriteRenderer.color = color;
        }
    }
}