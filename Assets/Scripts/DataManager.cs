using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Linq;

public class DataManager : MonoBehaviour
{
    public static DataManager instance;

    public static Player currentPlayer;

    public SaveData saveData;

    // Start is called before the first frame update
    void Awake()
    {
        if (instance != null)
            Destroy(gameObject);

        instance = this;

        string path = Application.persistentDataPath + "/saveFile.json";

        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            saveData = JsonUtility.FromJson<SaveData>(json);
        } else
            saveData = new SaveData();

        currentPlayer = new Player("Unknown", 0);

        DontDestroyOnLoad(gameObject);
    }

    public void Save()
    {
        saveData.gamePlayer.Add(currentPlayer);
        string json = JsonUtility.ToJson(saveData);
        File.WriteAllText(Application.persistentDataPath + "/saveFile.json", json);
    }
}

[System.Serializable]
public struct Player
{
    public string playerName;
    public int bestScore;

    public Player(string name, int score)
    {
        playerName = name;
        bestScore = score;
    }
}

[System.Serializable]
public class SaveData
{
    public List<Player> gamePlayer = new List<Player>();

    public List<Player> GetSortedPlayerList()
    {
        return gamePlayer.OrderByDescending(o => o.bestScore).ToList();
    }

    public Player GetBestPlayer()
    {
        if (gamePlayer.Count > 0)
            return GetSortedPlayerList()[0];
        else
            return new Player("", 0);
    }
}