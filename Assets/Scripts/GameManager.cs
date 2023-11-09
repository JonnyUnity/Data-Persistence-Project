using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public string CurrentPlayer;
    public string HighScorePlayer = "BOB";
    public int HighScore;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);

        Load();
    }

    public void UpdateHighScore(int newScore)
    {
        HighScore = newScore;
        HighScorePlayer = CurrentPlayer;
        Save();
    }

    public void Load()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            HighScorePlayer = data.PlayerName;
            HighScore = data.HighScore;
        }
    }

    public void Save()
    {
        SaveData data = new SaveData()
        {
            PlayerName = HighScorePlayer,
            HighScore = HighScore
        };

        string json = JsonUtility.ToJson(data);
        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    [System.Serializable]
    class SaveData
    {
        public string PlayerName;
        public int HighScore;
    }

}
