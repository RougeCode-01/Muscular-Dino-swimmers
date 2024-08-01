using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Events;
using UnityEngine.Serialization;

public class BombCounter : MonoBehaviour
{
    [SerializeField] private GameObject[] bombs;
    [SerializeField] private TMP_Text bombText;
    // Start is called before the first frame update
    void Start()
    {
        bombs = GameObject.FindGameObjectsWithTag("Bomb");
        bombText.text = bombs.Length.ToString();
    }

    // Update is called once per frame
    void UpdateBombText()
    {
        bombText.text = bombs.Length.ToString();
    }
}
