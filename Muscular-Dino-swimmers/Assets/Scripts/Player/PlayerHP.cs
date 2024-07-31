using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHP : MonoBehaviour
{
    public int playerHP = 3;
    private HealthManager healthManager;

    public void Start()
    {
        healthManager = HealthManager.Instance;
        healthManager.OnPlayerJoined(this.gameObject);
    }
}
