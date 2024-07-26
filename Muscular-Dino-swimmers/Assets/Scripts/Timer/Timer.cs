using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class Timer : MonoBehaviour
{

    private bool _timerActive;
    private float _currentTime;
    private int _timeInSeconds; 

    [SerializeField]
    protected int _startMinutes;

   [SerializeField]
    private int _startTimeInMinutes = 5;
    
    [SerializeField]
    private TMP_Text _text;

    void Start()
    {
        _currentTime = _startTimeInMinutes * 60;
        StartTimer();
        _timeInSeconds = 0;

    }


    void Update()
    {

        Debug.Log(_timerActive);

        
        if (_timerActive)
        {
            //Debug.Log("Time.deltaTime: " + Time.deltaTime);
            //Debug.Log("_currrentTime:" + _currentTime);

            _currentTime = _currentTime - Time.deltaTime; //good

             //Debug.Log("_currentTime after subtracting Time.deltaTime" + _currentTime);

        }


 
        TimeSpan time = TimeSpan.FromSeconds(_currentTime);

       // _timeInSeconds = time.Seconds;
       if (_timeInSeconds == (time.Seconds - 1))
        {
            Debug.Log("1 second has passed");
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
        /*
         */
    }

  
}
