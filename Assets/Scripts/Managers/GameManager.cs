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

    //Future implementation
    /*
    [SerializeField] string currentPetName;
    [SerializeField] GameObject currectPetGO;
    [SerializeField] GameObject momoPrefab;
    [SerializeField] GameObject tofuPrefab;
    */

    [SerializeField] Vector3 petPosition = new Vector3(-1.83f, -2.32f, 0f);

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
        ClosePauseMenu();

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
        //PauseMenu.SetActive(true);
        Joystick.SetActive(false);
        Time.timeScale = 0;
    }
    public void OpenPauseMenu()
    {
        PauseMenu.SetActive(true);
    }
    public void ClosePauseMenu()
    {
        PauseMenu.SetActive(false);
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
        {
            ResumeGame();
            ClosePauseMenu();
        }

        else
        {
            PauseGame();
            OpenPauseMenu();
        }
    }
     public void DisableJoystick()
    {
        Joystick.SetActive(false);
    }
    public void EnableJoystick()
    {
        Joystick.SetActive(true);

    }

    public void ExitGame()
    {
        Application.Quit();
    }
    public void PlayAgain()
    {
        SceneManager.LoadScene(1);

        ScoreManager.Instance.ResetScore();
        TimerManager.Instance.ResetTimer();
    }

    #region Pet Set 
    //Future implementation
    /*
    public void MomoSet()
    {
        currentPetName = "Momo";
        currectPetGO = Instantiate(momoPrefab);
        currectPetGO.transform.position = petPosition;
    }
    public void TofuSet()
    {
        currentPetName = "Tofu";
        currectPetGO = Instantiate(tofuPrefab);
        currectPetGO.transform.position = petPosition;
    }
    */
    #endregion

}
