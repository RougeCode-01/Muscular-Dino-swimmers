using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;



public class HealthManager : MonoBehaviour
{
    List<GameObject> players = new List<GameObject>();

    GameObject player1;
    GameObject player2;
    GameObject player3;
    GameObject player4;

    int deathCounter = 0;

    public void Start()
    {
        players.Add(player1);
        players.Add(player2);
        players.Add(player3);
        players.Add(player4);
    }
    public void OnPlayerJoined(PlayerInput playerInput)
    {


        // forget looking for an elegant solution for now, if else if chains make the world go around
        // if any of y'all have a better idea of how to put this together do let me know, I'd love to hear it


        if (player1 == null)
        {
            player1 = playerInput.gameObject;   // assign the gameobject to the player # var                
        }

        else if (player2 == null)
        {
            player2 = playerInput.gameObject;
        }

        else if (player3 == null)
        {
            player3 = playerInput.gameObject;
        }

        else if (player4 == null)
        {
            player4 = playerInput.gameObject;
        }
        else
        {

        }



    }

    public void OnPlayerLeft(PlayerInput playerInput)
    {
        // Don't know if we even need this here for our purposes
        if (playerInput.gameObject == player1)
        {

        }

        else if (playerInput.gameObject == player2)
        {

        }

        else if (playerInput.gameObject == player3)
        {

        }

        else if (playerInput.gameObject == player4)
        {

        }

        else
        {

        }
    }

    public void DamagePlayer(GameObject player)
    {
        PlayerHP hp = player.GetComponent<PlayerHP>();      // grab the HP script...
        hp.playerHP -= 1;
        if (hp.playerHP <= 0)                               // check if we're dead
        {
            PlayerDeath(player);
        }
    }

    public void PlayerDeath(GameObject dyingPlayer)
    {
        foreach (GameObject player in players)          // why can't we take the "player" variable in this foreach loop and modify it? Godot wouldn't make me tie my code in a knot like this
        {
            if (dyingPlayer == player)                  // Iterate through the player list until dyingPlayer is found
            {
                int pos = players.IndexOf(player);      // get the index of that player
                GameObject clear = players[pos];        // get the gameobject at that index
                clear = null;                           // set it to null so it can be used again
                Destroy(player);                        // and finally, destroy the dying player
                deathCounter++;
            }
        }
    }
}
