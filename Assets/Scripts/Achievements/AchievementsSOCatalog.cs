using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class AchievementsSOCatalog : ScriptableObject
{
    [SerializeField] List<AchievementSO> achievementsCatalog = new List<AchievementSO>();

    public List<AchievementSO> AchievementsCatalog
    {
        get { return achievementsCatalog; }
    }
}
