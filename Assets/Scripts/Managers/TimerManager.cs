using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TimerManager : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] float timeLeft;
    [SerializeField] int timeLeftInt;
    [SerializeField] float gameTime = 10f;
    [SerializeField] TextMeshProUGUI timeUI;

    #region Singleton
    private static TimerManager _instance;
    void Awake()
    {
        _instance = this; //Initialization of the private instance
    }
    public static TimerManager Instance
    {
        get
        {
            if (_instance == null)
            {
                Debug.Log("Timer Manager was NULL, creating game manager");
                GameObject go = new GameObject("TimerManager");
                go.AddComponent<TimerManager>();
            }
            return _instance;
        }
    }
    #endregion

    void Start()
    {
        ResetTimer();
    }

    public void ResetTimer()
    {
        timeLeft = gameTime;    
    }

    // Update is called once per frame
    void Update()
    {
        timeLeft -= Time.deltaTime;
        if (timeLeft>=0)
            UpdateTimeUI();
        else
            GameManager.Instance.ManageGameEnd();
    }
    private void UpdateTimeUI()
    {
        timeLeftInt = (int)timeLeft;
        timeUI.text = timeLeftInt.ToString();
    }

}
