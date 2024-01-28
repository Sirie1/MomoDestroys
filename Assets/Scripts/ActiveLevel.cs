using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveLevel : MonoBehaviour
{
    public float TimeLeft { get; private set; }
    [SerializeField] string _levelName;
    [SerializeField] bool _enabled;

    public void Init(float levelTime)
    {
        TimeLeft = levelTime;
        StartLevelTimer();
    }
    public void StartLevelTimer()
    {
        _enabled = true;
    }

    void Update()
    {
        if (_enabled) 
        {
            TimeLeft -=  Time.deltaTime;
        }
    }
}
