using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class DataManager : MonoBehaviour
{
    private static DataManager _instance;

    private string userDataSaveDirectory = "/UserData/";
    private string userDataFilename = "UserData.json";

    public UserData userData;

    [SerializeField] bool isNewPlayer;

    #region Singleton
    public static DataManager Instance
    {
        get
        {
            if (_instance == null)
            {
                GameObject go = new GameObject("DataManager");
                go.AddComponent<DataManager>();
            }

            return _instance;
        }
    }
    #endregion

    #region Awake and start
    void Awake()
    {
        _instance = this;
        isNewPlayer = false;
        LoadUserData();
        //***if is new player initialize new values
        if (isNewPlayer)
        {
            //***initialize something
            SaveUserData();
        }


    }
    #endregion

    #region Save and Load 

    //SaveUserData and LoadUserData are used to keep user data along different game sessions. For data persistance. 
    [ContextMenu("SaveUserData")]
    public void SaveUserData()
    {
        string dir = Application.persistentDataPath + userDataSaveDirectory;
        if (!Directory.Exists(dir))
        {
            Directory.CreateDirectory(dir);
            Debug.Log($"Directory {dir} was created");
        }

        if (!File.Exists(dir + userDataFilename))
        {

            File.Create(dir + userDataFilename).Close();
        }
        string json = JsonUtility.ToJson(userData, true);
        File.WriteAllText(dir + userDataFilename, json);
    }
    [ContextMenu("LoadUserData")]
    public void LoadUserData()
    {
        string dir = Application.persistentDataPath + userDataSaveDirectory;
        if (!Directory.Exists(dir))
        {
            Debug.LogWarning($"Directory {dir} was not found, could not load/create user data");
            return;
        }
        if (File.Exists(dir + userDataFilename))
        {
            string json = File.ReadAllText(dir + userDataFilename);
            userData = JsonUtility.FromJson<UserData>(json);
            Debug.Log($"User data loaded from {dir}");
        }
        else
        {
            Debug.Log("User Data not found");
            isNewPlayer = true;
            return;
        }
    }
    #endregion

    #region Class definitions formats to save
    [Serializable]
    public class UserData
    {
        public string UserName;
        public int BestScore;
        public int MatchesPlayed;
        public int LastLevelPassed;
        public List<AchievementsData> Achievements;
    }
    [Serializable]
    public class AchievementsData
    {
        public int ID;
        public int timesAchieved;
    }

    
    #endregion
    /*
    [Serializable]
    public class UserData
    {
        public string UserName;
        public int BestScore;
        public int MatchesPlayed;
        public int LastLevelPassed;
        public Dictionary<int, int> AchievementsDict;
    }
    public void AddAchievement(int ID)
    {
        if (userData.AchieventsDict.ContainsKey(ID))
            userData.AchievementsDict[ID]++;
        else
            userData.AchievementsDict.Add(ID, 0);
    }
    
    */


}
