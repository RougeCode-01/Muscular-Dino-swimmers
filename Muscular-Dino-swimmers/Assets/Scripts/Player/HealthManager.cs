using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;



public class HealthManager : MonoBehaviour
{

    // poached this solution from somebody on the forums - create a list to contain each player as they are created by the input manager.

    List<GameObject> players = new List<GameObject>();

    private void OnEnable()
    {
        PlayerInputManager.instance.onPlayerJoined += OnPlayerJoined;
        PlayerInputManager.instance.onPlayerLeft += OnPlayerLeft;
    }

    public void OnPlayerJoined(PlayerInput playerInput)
    {
        players.Add(playerInput.gameObject);
    }

    public void OnPlayerLeft(PlayerInput playerInput)
    {
        players.Remove(playerInput.gameObject);
    }
}
