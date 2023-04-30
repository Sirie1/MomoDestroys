using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class EndScreenController : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI scoreTextUI;
    [SerializeField] TextMeshProUGUI maxScoreTextUI;
    [SerializeField] GameObject ScoreTextGameObject;
    // Start is called before the first frame update
    void Start()
    {
        scoreTextUI.text = "£" + ScoreManager.Instance.Score.ToString();
        CheckBestScore();
        maxScoreTextUI.text = "£" + DataManager.Instance.userData.BestScore.ToString();

    }

    private void CheckBestScore()
    {
        if (ScoreManager.Instance.Score > DataManager.Instance.userData.BestScore)
        {
            DataManager.Instance.userData.BestScore = ScoreManager.Instance.Score;
            DataManager.Instance.SaveUserData();
        }
    }
}
