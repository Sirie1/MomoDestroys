using System.Collections;
using System.Collections.Generic;
using UnityEditor.SceneTemplate;
using UnityEngine;

public class ActiveLevelService : IProductService
{
    TimerService _timerService;
    private ActiveLevel _activeLevel;
    public ActiveLevelService(TimerService timerService) 
    {
        _timerService = timerService;
    }
    public void LoadNewLevel()
    {
        var activeLevelPrefab = Resources.Load<GameObject>("Prefabs/Levels/ActiveLevel");
        _activeLevel = GameObject.Instantiate(activeLevelPrefab).GetComponent<ActiveLevel>();
        _activeLevel.Init(60);
    }

    public ActiveLevel GetActiveLevel
    {
        get { return _activeLevel; }
    }
}
