using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Assertions.Must;

public struct PoopReach
{
    public string objectReached;
    public int bonusDestruction;
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

    [SerializeField] int poopOnBed;
    [SerializeField] int poopOnPicture;
    public List<PoopReach> ReachedPoopList = new List<PoopReach>();
       
    Dictionary<string, int> bonusPoopCost = new Dictionary<string, int>()
    {

        {"Furniture Table", 10 },
        {"Furniture Bench", 5 },
        {"Furniture Picture", 20 },
        {"Furniture Small Table", 5},
        {"Furniture Chest", 10},
        {"Furniture Art Picture", 50}
    };

    public int Score
    {
        get { return score; }
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

        Debug.Log("Pooping on " + poop.ObjectPooped.name);
        if(ReachedPoopList.Count <1)
        {
            Debug.Log("First poop, creating list");
            PoopReach newObjectReached = new PoopReach();
            newObjectReached.objectReached = poop.ObjectPooped.name;
            //Search in dictionary for corresponding bonus 
            //newObjectReached.bonusDestruction = bonusPoopCost[poop.ObjectPooped.name];
            if (!bonusPoopCost.TryGetValue(poop.ObjectPooped.name, out newObjectReached.bonusDestruction))
            {
                Debug.LogWarning("Dict doesn't have the value " + poop.ObjectPooped.name);
            }
            newObjectReached.timesReached = 1;

            ReachedPoopList.Add (newObjectReached);
        }
        else
        {
            Debug.Log("Poop list not mull");
            //Check list if existing
            bool wasFoundInList = false;
            for (int i = 0; i < ReachedPoopList.Count; i++)
            {
                Debug.Log($"Checking element n: {i}");
                if (ReachedPoopList[i].objectReached == poop.ObjectPooped.name)
                {
                    Debug.Log ("Pooped repeated " + poop.ObjectPooped.name);
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
                //Search in dictionary for corresponding bonus 
                //newObjectReached.bonusDestruction = bonusPoopCost[poop.ObjectPooped.name];
                if (!bonusPoopCost.TryGetValue(poop.ObjectPooped.name, out newObjectReached.bonusDestruction))
                {
                    Debug.LogWarning("Dict doesn't have the value " + poop.ObjectPooped.name);
                }
                newObjectReached.timesReached = 1;

                ReachedPoopList.Add(newObjectReached);
            }
        }
    }
    public void AddPee()
    {
        score += 150;
        UpdateUI();
    }
    void UpdateUI()
    {
        scoreText.text = "-£" + score.ToString();
    }

}
