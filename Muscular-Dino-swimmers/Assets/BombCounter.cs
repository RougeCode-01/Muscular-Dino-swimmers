using System;
using System.Collections;
using System.Collections.Generic;
using Microlight.MicroAudio;
using UnityEngine;
using TMPro;
using Unity.VisualScripting;
using UnityEngine.Events;
using UnityEngine.Serialization;

public class BombCounter : MonoBehaviour
{
    [SerializeField] private GameObject[] bombs;
    [SerializeField] private TMP_Text bombText;

    [SerializeField] public AudioClip uiClip1;
    // Start is called before the first frame update
    void Start()
    {
        bombs = GameObject.FindGameObjectsWithTag("Bomb");
        bombText.text = bombs.Length.ToString();
        
    }

    private void OnEnable()
    {
        BombScript.onBombDefused.AddListener(UpdateBombText);
    }

    // Update is called once per frame
    void UpdateBombText()
    {
        MicroAudio.PlayUISound(uiClip1);
        StartCoroutine(wait());
        bombs = GameObject.FindGameObjectsWithTag("Bomb");
        bombText.text = bombs.Length.ToString();
    }

    IEnumerator wait()
    {
        yield return new WaitForSeconds(1);
    }



}
