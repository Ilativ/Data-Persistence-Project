using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class DataManager : MonoBehaviour
{
    public static DataManager instance;

    public static string currentPlayerName;

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

        DontDestroyOnLoad(gameObject);
    }

    public void Save(int m_Points)
    {
        saveData.topPlayerName = currentPlayerName;
        saveData.bestScore = m_Points;
        string json = JsonUtility.ToJson(saveData);
        File.WriteAllText(Application.persistentDataPath + "/saveFile.json", json);
    }
}

[System.Serializable]
public class SaveData
{
    public int bestScore;
    public string topPlayerName;

    //public string currentPlayerName;
}