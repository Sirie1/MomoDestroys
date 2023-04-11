using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class EndScreenController : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI scoreTextUI;
    // Start is called before the first frame update
    void Start()
    {
        scoreTextUI.text = "£" + ScoreManager.Instance.Score.ToString();
        CheckBestScore();
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
