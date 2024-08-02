using System.Collections;
using Microlight.MicroAudio;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class BombCounter : MonoBehaviour
{
    [SerializeField] private TMP_Text bombText;
    [SerializeField] public AudioClip uiClip1;
    private int previousBombCount = -1;

    private void Start()
    {
        UpdateBombText();
    }

    private void Update()
    {
        var bombs = GameObject.FindGameObjectsWithTag("Bomb");
        if (bombs.Length != previousBombCount)
        {
            previousBombCount = bombs.Length;
            UpdateBombText();
        }
    }

    private void UpdateBombText()
    {
        MicroAudio.PlayUISound(uiClip1);
        var bombs = GameObject.FindGameObjectsWithTag("Bomb");
        bombText.text = bombs.Length.ToString();

        if (bombs.Length == 0)
        {
            SceneManager.LoadScene(2);
        }
    }
}