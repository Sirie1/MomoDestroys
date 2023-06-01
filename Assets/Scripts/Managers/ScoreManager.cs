using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Assertions.Must;
using System;

//Used to count how many times an object was pooped
public struct PoopReach
{
    public string objectReached;
    //public int bonusDestruction;
    public int timesReached;
}
public struct PeeReach
{
    public string objectReached;
    public int timesReached;
}
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
    [SerializeField] AchievementsController achievementsController;
    [SerializeField] FurnitureCatalogSO furnitureCatalogSO;
    //Make a list of objects pooped
    public List<PoopReach> ReachedPoopList = new List<PoopReach>();
    public List<PeeReach> ReachedPeeList = new List<PeeReach>();
       /*
    Dictionary<string, int> bonusPoopCost = new Dictionary<string, int>()
    {

        {"Furniture Table", 10 },
        {"Furniture Bench", 5 },
        {"Furniture Picture", 20 },
        {"Furniture Small Table", 5},
        {"Furniture Chest", 10},
        {"Furniture Art Picture", 50}
    };*/

    public int Score
    {
        get { return score; }
        set { score = value; }
    }
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
    public void AddPoop(Poop poop)
    {

        score += 150;
        UpdateUI();
    }
    public void AddPoopCollision(Poop poop)
    {
        //Check if adds to achievements
        if (poop.ObjectPooped.GetComponent<Furniture>() != null)
        {
            achievementsController.CheckAchievement(AchievementSO.AchievementType.Poop, poop.ObjectPooped.GetComponent<Furniture>());
        }
        //Debug.Log("Pooping on " + poop.ObjectPooped.name);
        if (ReachedPoopList.Count <1)
        {
            //Debug.Log("First poop, creating list");
            PoopReach newObjectReached = new PoopReach();
            newObjectReached.objectReached = poop.ObjectPooped.name;
            /*
            //Search in dictionary for corresponding bonus 
            if (!bonusPoopCost.TryGetValue(poop.ObjectPooped.name, out newObjectReached.bonusDestruction))
            {
                Debug.LogWarning("Dict doesn't have the value " + poop.ObjectPooped.name);
            }*/
            newObjectReached.timesReached = 1;
            ReachedPoopList.Add (newObjectReached);
        }
        else
        {
            //Check list if existing
            bool wasFoundInList = false;
            for (int i = 0; i < ReachedPoopList.Count; i++)
            {
                if (ReachedPoopList[i].objectReached == poop.ObjectPooped.name)
                {
                    //Debug.Log ("Pooped repeated " + poop.ObjectPooped.name);
                    PoopReach tempStruct = ReachedPoopList[i];
                    tempStruct.timesReached++;
                    ReachedPoopList[i] = tempStruct;
                    wasFoundInList = true;
                    break;
                }
            }
            //if Reaches here it means the list did not contain the value, so creating a new
            if (!wasFoundInList)
            {
                PoopReach newObjectReached = new PoopReach();
                newObjectReached.objectReached = poop.ObjectPooped.name;
                /*
                //Search in dictionary for corresponding bonus 
                if (!bonusPoopCost.TryGetValue(poop.ObjectPooped.name, out newObjectReached.bonusDestruction))
                {
                    Debug.LogWarning("Dict doesn't have the value " + poop.ObjectPooped.name);
                }*/
                //Search in furniture catalog for corresponding Bonus destruction
                newObjectReached.timesReached = 1;
                ReachedPoopList.Add(newObjectReached);
            }
        }
    }
    public void AddPeeCollision(Pee pee)
    {
        if (pee.ObjectPeed.GetComponent<Furniture>() != null)
        {
            achievementsController.CheckAchievement(AchievementSO.AchievementType.Pee, pee.ObjectPeed.GetComponent<Furniture>());
        }
        if (ReachedPeeList.Count < 1)
        {
            PeeReach newObjectReached = new PeeReach();
            newObjectReached.objectReached = pee.ObjectPeed.name;

            newObjectReached.timesReached = 1;
            ReachedPeeList.Add(newObjectReached);
        }
        else
        {
            bool wasFoundInList = false;
            for (int i = 0; i < ReachedPeeList.Count; i++)
            {
                if (ReachedPeeList[i].objectReached == pee.ObjectPeed.name)
                {
                    PeeReach tempStruct = ReachedPeeList[i];
                    tempStruct.timesReached++;
                    ReachedPeeList[i] = tempStruct;
                    wasFoundInList = true;
                    break;
                }
            }
            if (!wasFoundInList)
            {
                PeeReach newObjectReached = new PeeReach();
                newObjectReached.objectReached = pee.ObjectPeed.name;
                //Search in furniture catalog for corresponding Bonus destruction
                newObjectReached.timesReached = 1;
                ReachedPeeList.Add(newObjectReached);
            }
        }
    }

    public void AddPee()
    {
        score += 150;
        UpdateUI();
    }
    public int GetBonusDestruction(string furnitureName, DogStateController.StatesName action)
    {
        foreach (FurnitureSO furnitureSO in furnitureCatalogSO.FurnitureCatalog)
        {
            if (furnitureSO.FurnitureName == furnitureName)
            {
                if (action == DogStateController.StatesName.Poo)
                    return furnitureSO.BonusForPoop;
                else if (action == DogStateController.StatesName.Pee)
                    return furnitureSO.BonusForPee;
                else
                {
                    Debug.LogWarning ("Tried to get bonus destruction but action was not valid");
                    return 0;
                }
            }

        }
        Debug.LogWarning ("Could not find bonus destruction for " + furnitureName);
        return 0;   
    }
    void UpdateUI()
    {
        scoreText.text = "-$" + score.ToString();
    }

}
