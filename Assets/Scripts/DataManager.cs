using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;


public class DataManager : MonoBehaviour
{
    public static DataManager Data;
    private string dataPath = "/PlayerData/player.json";

    public int Score
    {
        get; set;
    }

    void Awake()
    {
        if(Data != null)
        {
            Destroy(gameObject);
            return;
        }

        Data = this;
        DontDestroyOnLoad(gameObject);
    }

    public void SaveData()
    {
        string json = JsonUtility.ToJson(Data);
        File.WriteAllText(Application.persistentDataPath + dataPath, json);
    }

    public void LoadData()
    {
        if(File.Exists(Application.persistentDataPath + dataPath))
        {
            string json = File.ReadAllText(Application.persistentDataPath + dataPath);
            Data = JsonUtility.FromJson<DataManager>(json);
        }
    }
}
