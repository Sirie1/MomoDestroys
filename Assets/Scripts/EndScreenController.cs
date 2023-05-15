using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class EndScreenController : MonoBehaviour
{
    [SerializeField] GameObject scoreTextParentUI;
    [SerializeField] TextMeshProUGUI maxScoreTextUI;
    [SerializeField] GameObject ScoreTextGameObject;
    [SerializeField] GameObject bonusTextPrefab;
    [SerializeField] TextMeshProUGUI totalScoreText;

    void Start()
    {
        scoreTextParentUI.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = "Base Score $" + ScoreManager.Instance.Score.ToString();
        CalculateScore();
        CheckBestScore();
        maxScoreTextUI.text = "$" + DataManager.Instance.userData.BestScore.ToString();

    }

    private void CheckBestScore()
    {
        if (ScoreManager.Instance.Score > DataManager.Instance.userData.BestScore)
        {
            DataManager.Instance.userData.BestScore = ScoreManager.Instance.Score;
            DataManager.Instance.SaveUserData();
        }
    }
    private void CalculateScore()
    {
        int totalScore = ScoreManager.Instance.Score;
        for (int i = 0; i < ScoreManager.Instance.ReachedPoopList.Count; i++)
        {

            GameObject tempBonusText = Instantiate(bonusTextPrefab, scoreTextParentUI.transform);

            //int bonusScore = ScoreManager.Instance.ReachedPoopList[i].timesReached * ScoreManager.Instance.ReachedPoopList[i].bonusDestruction;
            int bonusScore = ScoreManager.Instance.ReachedPoopList[i].timesReached * ScoreManager.Instance.GetBonusDestruction(ScoreManager.Instance.ReachedPoopList[i].objectReached, DogStateController.StatesName.Poo);
            tempBonusText.GetComponent<TextMeshProUGUI>().text = ScoreManager.Instance.ReachedPoopList[i].objectReached + " X" + ScoreManager.Instance.ReachedPoopList[i].timesReached + " $" + bonusScore;
            tempBonusText.GetComponent<TextMeshProUGUI>().color = Color.green;
            totalScore = totalScore + bonusScore;
        }
        totalScoreText.text = "$" + totalScore.ToString();
    }
}
