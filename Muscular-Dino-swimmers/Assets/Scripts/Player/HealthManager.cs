using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;



public class HealthManager : MonoBehaviour
{
    List<GameObject> players = new List<GameObject>();


    public GameObject empty; // making an empty and attaching it to the HM so I can fill spaces in the list with something to be replaced
    GameObject player1;      // this probably is not necessary now that I've proceeded further in my debugging, I'll pull it out later if we don't need this behavior
    GameObject player2;
    GameObject player3;
    GameObject player4;

    int deathCounter = 0;


    public void Start()
    {
        player1 = empty;
        player2 = empty;
        player3 = empty;
        player4 = empty;
        players.Add(player1);
        players.Add(player2);
        players.Add(player3);
        players.Add(player4);
        //foreach (GameObject go in players)
        //{
        //    Debug.Log(go.ToString());
        //}

    }
    public void OnPlayerJoined(GameObject player)
    {


        // forget looking for an elegant solution for now, if else if chains make the world go around
        // if any of y'all have a better idea of how to put this together do let me know, I'd love to hear it
        Debug.Log("OnPlayerJoined");

        if (player1 == empty)
        {
            player1 = player;   // assign the gameobject to the player # var                
            Debug.Log("assigned player 1");
        }

        else if (player2 == empty)
        {
            player2 = player;
            Debug.Log("assigned player 2");
        }

        else if (player3 == empty)
        {
            player3 = player;
            Debug.Log("assigned player 3");
        }

        else if (player4 == empty)
        {
            player4 = player;
            Debug.Log("assigned player 4");
        }
        else
        {

        }



    }

    public void OnPlayerLeft(GameObject player)
    {
        // Don't know if we even need this here for our purposes
        if (player == player1)
        {

        }

        else if (player == player2)
        {

        }

        else if (player == player3)
        {

        }

        else if (player == player4)
        {

        }

        else
        {

        }
    }

    public void DamagePlayerHM(GameObject player)
    {
        PlayerHP hp = player.GetComponent<PlayerHP>();      // grab the HP script...
        hp.playerHP -= 1;
        Debug.Log(hp.playerHP);
        if (hp.playerHP <= 0)                               // check if we're dead
        {
            PlayerDeath(player);
        }
    }


    public void PlayerDeath(GameObject dyingPlayer)
    {
        //Debug.Log("player death function activated");
        foreach (GameObject p in players)          // why can't we take the "player" variable in this foreach loop and modify it? Godot wouldn't make me tie my code in a knot like this
        {
            Destroy(dyingPlayer);                        
            deathCounter++;
            if (p == dyingPlayer)                  // Iterate through the player list until dyingPlayer is found
            {
                Debug.Log("player death foreach function activated");
                int pos = players.IndexOf(p);      // get the index of that player

                GameObject clear = players[pos];        // get the gameobject at that index
                clear = empty;                           // set it to null so it can be used again
                //Destroy(dyingPlayer);                        // and finally, destroy the dying player
                //deathCounter++;
            }
        }
    }
}