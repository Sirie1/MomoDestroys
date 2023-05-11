using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AchievementsController : MonoBehaviour
{
    [SerializeField] AchievementsSOCatalog achievementSOList;
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
}
