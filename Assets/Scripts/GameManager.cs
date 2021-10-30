using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;


public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public string userName;

    public string topUserName;
    public int score;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
        LoadScore();
    }


    [System.Serializable]
    public class SaveData
    {
        public string userName;
        public int score;

        public SaveData(string UserName, int Score)
        {
            userName = UserName;
            score = Score;
        }

    }

    public void SaveScore(string UserName, int Score)
    {
        SaveData saveData = new SaveData(UserName, Score);
        string json = JsonUtility.ToJson(saveData);
        File.WriteAllText(Application.persistentDataPath + "/breakOutSaveFile.json", json);
        Debug.Log(Application.persistentDataPath + "/breakOutSaveFile.json" + " " + UserName + ": " + Score);
    }

    public void LoadScore()
    {
        string path = Application.persistentDataPath + "/breakOutSaveFile.json";

        if(File.Exists(path)) {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);
            topUserName = data.userName;
            score = data.score;

        }
    }


}
