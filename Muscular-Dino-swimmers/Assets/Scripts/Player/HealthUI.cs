using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HealthUI : MonoBehaviour
{
    public TextMeshProUGUI Player1;
    public TextMeshProUGUI Player2;
    public TextMeshProUGUI Player3;
    public TextMeshProUGUI Player4;

    public PlayerHP playerHP1;
    public PlayerHP playerHP2;
    public PlayerHP playerHP3;
    public PlayerHP playerHP4;

    private int hpOutput1;
    private int hpOutput2;
    private int hpOutput3;
    private int hpOutput4;

    public void AddPlayer1(GameObject player)
    {
        playerHP1 = player.GetComponent<PlayerHP>();
        hpOutput1 = playerHP1.playerHP;
        Player1.text = "P1: " + hpOutput1.ToString();
    }

    public void AddPlayer2(GameObject player)
    {
        playerHP2 = player.GetComponent<PlayerHP>();
        hpOutput2 = playerHP2.playerHP;
        Player2.text = "P2: " + hpOutput2.ToString();
    }

    public void AddPlayer3(GameObject player)
    {
        playerHP3 = player.GetComponent<PlayerHP>();
        hpOutput3 = playerHP3.playerHP;
        Player3.text = "P3: " + hpOutput3.ToString();
    }

    public void AddPlayer4(GameObject player)
    {
        playerHP4 = player.GetComponent<PlayerHP>();
        hpOutput4 = playerHP4.playerHP;
        Player4.text = "P4: " + hpOutput4.ToString();
    }

    public void RemovePlayer1()
    {
        playerHP1 = null;
        hpOutput1 = 0;
        Player1.text = "X_X";
    }
    
    public void RemovePlayer2()
    {
        playerHP2 = null;
        hpOutput2 = 0;
        Player2.text = "X_X";
    }
    
    public void RemovePlayer3()
    {
        playerHP3 = null;
        hpOutput3 = 0;
        Player3.text = "X_X";
    }
    
    public void RemovePlayer4()
    {
        playerHP4 = null;
        hpOutput4 = 0;
        Player4.text = "X_X";
    }

    public void Update()
    {
        if (playerHP1 != null)
        {
            hpOutput1 = playerHP1.playerHP;
            Player1.text = "P1: " + hpOutput1.ToString();
        }
        if (playerHP2 != null)
        {
            hpOutput2 = playerHP2.playerHP;
            Player2.text = "P2: " + hpOutput2.ToString();
        }
        if (playerHP3 != null)
        {
            hpOutput3 = playerHP3.playerHP;
            Player3.text = "P3: " + hpOutput3.ToString();
        }
        if (playerHP4 != null)
        {
            hpOutput4 = playerHP4.playerHP;
            Player4.text = "P4: " + hpOutput4.ToString();
        }
    }

}
