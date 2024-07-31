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

    private TimeSpan time; //Holds our time, after being converted into seconds. 

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

    //TODO modularize audio beeping 

    void Update()
    {   
        if (_timerActive == true) //If our timer is on, check for these conditions on the variable _currentTime. 
        {
            _currentTime = _currentTime - Time.deltaTime;

            if (_currentTime <= _lastMinute) //If we have reached the _lastMinute, we check that the number has changed, and if so, we play a beep. 
            {
                beep -= Time.deltaTime;
                if (beep <= 0)
                {
                    _speaker.Play();
                    beep = _playBeep; // reset Interval
                    Debug.Log("beep");
                }
            }

            if (_currentTime <= dangerTimeThreshold) //If we have reached dangerTimeThreshold, we send out an event to the world. 
            {
                OnDangerTime?.Invoke(); //Activate OnDangerTime event 
            }


            if (_currentTime <= 0) //Check if the timer has reached 0 
            {
                _timerActive = false; 
            }

            time = TimeSpan.FromSeconds(_currentTime); //Updates our time in seconds variable. 
            UpdateTimer(); //Update the canvas text 

        }

        else // Our timer is off, _timerActive == false  
        {
            TimerEnd?.Invoke();  //Send an event to the world (which will end the game) 

        }
        
    }

    /// <summary>
    /// Updates the TMP.text field with the converted time. 
    /// </summary>
    void UpdateTimer() 
    {
        _text.text = time.Minutes.ToString() + ":" + time.Seconds.ToString(); //Converts the time to a normal 00:00:00 format, then sets it to the text field. 
    }

    void StartTimer()
    {
        _timerActive = true;
    }

    void StopTimer()
    {
        _timerActive = false;
        Debug.Log("This is supposed to happen when the timer reaches 0");
    }

    void BeepEachSecond()
    {
        
    }

  
}
