using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject EndScreen;
    #region Singleton
    private static GameManager _instance;
    public static GameManager Instance
    {
        get
        {
            if (_instance == null)
            {
                Debug.Log("Game Manager was NULL, creating game manager");
                GameObject go = new GameObject("GameManager");
                go.AddComponent<GameManager>();
            }
            return _instance;
        }
    }
    #endregion
    void Awake()
    {
        _instance = this; //Initialization of the private instance
    }
    private void Start()
    {
        StartGame();
    }
    public void StartGame()
    {
        EndScreen.SetActive(false);

        ResumeGame();

        TimerManager.Instance.ResetTimer();
        //DataManager.Instance.LoadUserData();
    }
    public void ManageGameEnd()
    {
        PauseGame();
        EndScreen.SetActive(true);
    }
    void PauseGame()
    {
        Time.timeScale = 0;
    }
    void ResumeGame()
    {
        Time.timeScale = 1;
    }
}
