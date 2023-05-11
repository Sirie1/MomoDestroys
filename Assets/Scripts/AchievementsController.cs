using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AchievementsController : MonoBehaviour
{
    //Checks if dog messed on object, and corresponds to an achievement. 
    public void CheckAchievement(AchievementSO.AchievementType action, GameObject affectedObject )
    {

        DataManager.Instance.AddAchievement(0);
        DataManager.Instance.SaveUserData();
    }
}
