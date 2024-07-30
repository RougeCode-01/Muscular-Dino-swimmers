using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using UnityEngine.Events;

public class Timer : MonoBehaviour
{
    public UnityEvent TimerEnd;
    public UnityEvent OnDangerTime; 

    private bool _timerActive;
    private float _currentTime;
    private int _timeInSeconds;

    public float dangerTimeThreshold;  

    [SerializeField]
    private AudioClip _beepingSound;

    [SerializeField]
    private AudioSource _speaker;

    [SerializeField]
    private float _lastMinute; //This is for last minute time 

    [SerializeField]
    protected int _startMinutes;

   [SerializeField]
    private float _startTimeInMinutes = 5;

    [SerializeField]
    private float _playBeep = 1f; //this is the interval that plays Sound

    [SerializeField]
    private TMP_Text _text;

    float beep = 0;

    void Start()
    {
        _currentTime = _startTimeInMinutes * 60;
        StartTimer();
        _timeInSeconds = 0;
        _speaker.clip = _beepingSound;
    }


    void Update()
    {   
        if (_timerActive)
        {
            _currentTime = _currentTime - Time.deltaTime; 
        }

        if (_currentTime <= _lastMinute)
        {
            beep -= Time.deltaTime;
            if(beep <= 0)
            {
                _speaker.Play();
                beep = _playBeep; // reset Interval
            }
        }
        if (_currentTime <= dangerTimeThreshold)
        {
           // Debug.Log("dangerTimeThreshold reached: " + dangerTimeThreshold);
            OnDangerTime?.Invoke();
        }
 
        TimeSpan time = TimeSpan.FromSeconds(_currentTime);

       // Debug.Log("_currentTime: " + _currentTime);

        if (_currentTime <= 0)
        {
            TimerEnd?.Invoke();
        }
        

        Debug.Log("_timeInSeconds: " + _timeInSeconds);


        _text.text = time.Minutes.ToString() + ":" + time.Seconds.ToString();
    }

    void StartTimer()
    {
        _timerActive = true;
    }

    void StopTimer()
    {
        _timerActive = false;
    }

    void BeepEachSecond()
    {
        
    }

  
}
