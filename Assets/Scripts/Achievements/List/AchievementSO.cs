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
    public string Title;
    public AchievementType achievementType;
    public string Text;
    public List<Furniture.ObjectTypes> interactionObject = new List<Furniture.ObjectTypes>();
    public int complete;
    public int reward;

}