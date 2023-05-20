using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class DataPersistenceManager : MonoBehaviour
{
    public static DataPersistenceManager Instance;

    public static string UserName;

    public string bestUserName;
    public int bestScore;

    private void Awake()
    {
        // start of new code
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        // end of new code

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        SaveInfo();
    }

    [System.Serializable]
    class SaveData
    {
        public string BestUserName;
        public int BestScore;
    }

    public void SaveInfo()
    {
        SaveData data = new SaveData();

        data.BestUserName = "1"; //MainManager.BestUserName;
        data.BestScore = 1;  //MainManager.BestScore;

        string json = JsonUtility.ToJson(data);

        Debug.Log(json);

        File.WriteAllText(Application.persistentDataPath + "/saveinfofile.json", json);
    }

    public void LoadInfo()
    {
        string path = Application.persistentDataPath + "/saveinfofile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);
        }
    }
}
