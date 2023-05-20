using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class DataPersistenceManager : MonoBehaviour
{
    // Start() and Update() methods deleted - we don't need them right now

    public static DataPersistenceManager Instance;

    public string BestUser;
    public int BestScore; // new variable declared

    public static int BestUserScore;

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

        LoadData();
    }

    private void Start()
    {
        
    }

    [System.Serializable]
    class Data
    {
        public string BestUser;
        public int BestScore;
    }

    public void SaveData()
    {
        Data data = new Data();
        data.BestUser = MainManager.BestName;
        data.BestScore = MainManager.BestScore;

        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    public void LoadData()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            Data data = JsonUtility.FromJson<Data>(json);

            BestUser = data.BestUser;
            BestScore = data.BestScore;

            Debug.Log(BestScore);
        }
    }
}
