using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class AchievementSO : ScriptableObject
{
    public enum AchievementType
    {
        Chew,
        Poop,
        Pee,
        Eat
    }
    public int id;
    public string Name;
    public AchievementType achievementType;
    public string Text;
    public List<GameObject> interactionObject = new List<GameObject>();
    public int reward;

}