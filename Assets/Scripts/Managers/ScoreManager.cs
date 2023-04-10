using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class ScoreManager : MonoBehaviour
{
    #region Singleton
    private static ScoreManager _instance;
    public static ScoreManager Instance
    {
        get
        {
            if (_instance == null)
            {
                Debug.Log("Score Manager was NULL, creating game manager");
                GameObject go = new GameObject("ScoreManager");
                go.AddComponent<ScoreManager>();
            }
            return _instance;
        }
    }
    #endregion

    [SerializeField] int score;
    [SerializeField] TextMeshProUGUI scoreText;

    [SerializeField] int poopOnBed;
    [SerializeField] int poopOnPicture;

    void Awake()
    {
        _instance = this; //Initialization of the private instance
    }

    public void ResetScore()
    {
        score = 0;
    }
    public void AddScore()
    {
        score ++;
        UpdateUI();
    }
    public void AddPoop()
    {
        score += 150;
        UpdateUI();
    }
    void UpdateUI()
    {
        scoreText.text = "-$" + score.ToString();
    }
}
