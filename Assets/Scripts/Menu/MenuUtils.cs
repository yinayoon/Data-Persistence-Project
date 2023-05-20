using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuUtils : MonoBehaviour
{
    public Text bestScore;
    public InputField userNameInputField;
    public Button startButton;

    public static string UserName;

    void Start()
    {
        startButton.enabled = false;
        bestScore.text = $"Best Score : {DataPersistenceManager.Instance.BestUser} : {DataPersistenceManager.Instance.BestScore.ToString()}";
    }

    private void Update()
    {
        UserName = userNameInputField.text;

        if (UserName.Length > 0)
        {
            startButton.enabled = true;
        }
        else
        {
            startButton.enabled = false;
        }
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
