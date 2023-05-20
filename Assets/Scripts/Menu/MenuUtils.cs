using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuUtils : MonoBehaviour
{
    public Text bestScore;

    void Start()
    {
        bestScore.text = $"Best Score : {DataPersistenceManager.Instance.BestUser} : {DataPersistenceManager.Instance.BestScore.ToString()}";
    }

    public void StartNew()
    {
        SceneManager.LoadScene(1);
    }

    public void Exit()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit(); // original code to quit Unity player
#endif
    }
}
