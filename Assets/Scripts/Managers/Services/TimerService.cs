using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimerService : IProductService
{
    public float TimeLeft { get; private set; }
    public float SessionTime { get; private set;}
    [SerializeField] int timeLeftInt;
    [SerializeField] float gameTime = 10f;
    [SerializeField] float updatedTimer;
    public TimerService()
    {
    }
    void Update()
    {

    }

    public void ResetTimer()
    {
        TimeLeft = gameTime;
    }
}
