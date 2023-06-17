using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class AchievementsController : MonoBehaviour
{
    [SerializeField] AchievementsSOCatalog achievementSOList;
    //Line prefab shoud be initialized inside panel gameobject
    [SerializeField] GameObject linePrefab;
    [SerializeField] Transform panel;



    private void OnEnable()
    {
        GameManager.Instance.PauseGame();
        GenerateEmpyAchievementList();
        SetCurrentAchievementsList();
    }
    private void OnDisable()
    {
     //       GameManager.Instance.ResumeGame();
    }
    //Checks if dog messed on object, and corresponds to an achievement. 
    public void CheckAchievement(AchievementSO.AchievementType action, Furniture affectedObject )
    {
        foreach ( var achievement in achievementSOList.AchievementsCatalog)
        {
            if (achievement.achievementType == action)
            {
                foreach (var myType in achievement.interactionObject)
                {
                    if (myType == affectedObject.ObjectType)
                    {
                        Debug.Log("Achievement reached");
                        DataManager.Instance.AddAchievement(achievement.id);

                        DataManager.Instance.SaveUserData();
                    }
                }
            }
        }
    }

    void GenerateEmpyAchievementList()
    {
        foreach (var achievement in achievementSOList.AchievementsCatalog)
        {
            var templine = Instantiate(linePrefab, panel );
            if (DataManager.Instance.userData.AchievementsDict.ContainsKey (achievement.id))
            {
                templine.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = achievement.Title;
                templine.transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = achievement.Text;
                templine.transform.GetChild(2).GetComponent<TextMeshProUGUI>().text = DataManager.Instance.userData.AchievementsDict[achievement.id].ToString() + 
                                                                                                                            "/" + achievement.complete.ToString();
                templine.transform.GetChild(3).GetComponent<Image>().sprite = achievement.icon;
            }
            else
            {
                templine.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = "???";
                templine.transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = "";
                templine.transform.GetChild(2).GetComponent<TextMeshProUGUI>().text = "0/" + achievement.complete.ToString();
            }

        }
    }

    void SetCurrentAchievementsList() 
    {

    }
}
