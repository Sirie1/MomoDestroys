using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject EndScreen;
    [SerializeField] GameObject PauseMenu;
    [SerializeField] GameObject Joystick;
    bool isGamePaused;
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

    public void StartGame()
    {

        EndScreen.SetActive(false);

        ResumeGame();

        ScoreManager.Instance.ResetScore();
        TimerManager.Instance.ResetTimer();
        //DataManager.Instance.LoadUserData();
    }
    public void ManageGameEnd()
    {
        //PauseGame();
        EndScreen.SetActive(true);
    }
    public void PauseGame()
    {
        isGamePaused = true;
        PauseMenu.SetActive(true);
        Joystick.SetActive(false);
        Time.timeScale = 0;
    }
    public void ResumeGame()
    {
        isGamePaused = false;
        PauseMenu.SetActive(false);
        Joystick.SetActive(true);
        Time.timeScale = 1;
    }
    public void TogglePause()
    { 
        if(isGamePaused)
            ResumeGame();
        else
            PauseGame();
    }


    public void ExitGame()
    {
        Application.Quit();
    }
    public void PlayAgain()
    {
        SceneManager.LoadScene(0);

        ScoreManager.Instance.ResetScore();
        TimerManager.Instance.ResetTimer();
    }
}
