using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class Manager : MonoBehaviour
{
    public static Manager Instance;

    public string playerName;
    public int playerScore;
    public int highScore = 0;
    public string highScoreOwnerName;

    private void Awake()
    {
        if(Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);

        LoadInfo();
    }

    private void Start()
    {
        if(playerScore > highScore)
        {
            highScore = playerScore;
        }
    }

    public class SaveData
    {
        public int bestScore;
        public string bestScoreName;
    }

    public void SaveInfo()
    {
        SaveData saveData = new SaveData();
        saveData.bestScore = highScore;
        saveData.bestScoreName = highScoreOwnerName;

        string json = JsonUtility.ToJson(saveData);
        File.WriteAllText(Application.persistentDataPath + "/savedata.json", json);
    }

    private void LoadInfo()
    {
        string path = Application.persistentDataPath + "/savedata.json";
        if(File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData saveData = JsonUtility.FromJson<SaveData>(json);

            highScore = saveData.bestScore;
            highScoreOwnerName = saveData.bestScoreName;

        }
    }
}
