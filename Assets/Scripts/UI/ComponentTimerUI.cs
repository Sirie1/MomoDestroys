using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ComponentTimerUI : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI _timeUI;
    private int _timeLeftInt;
    ActiveLevel _activeLevel;

    void Start()
    {
        _activeLevel = ServiceLocator.GetService<ActiveLevelService>().GetActiveLevel;
    }

    // Update is called once per frame
    void Update()
    {
        UpdateTimeUI();
    }
    private void UpdateTimeUI()
    {
        _timeLeftInt = (int)_activeLevel.TimeLeft;
        _timeUI.text = _timeLeftInt.ToString();
    }
}
