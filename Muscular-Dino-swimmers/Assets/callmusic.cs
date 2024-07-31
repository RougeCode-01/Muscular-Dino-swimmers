using System.Collections;
using System.Collections.Generic;
using Microlight.MicroAudio;
using UnityEngine;

public class callmusic : MonoBehaviour
{
    [SerializeField] private AudioClip _music;
    // Start is called before the first frame update
    void Start()
    {
        MicroAudio.PlayOneTrack(_music);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
