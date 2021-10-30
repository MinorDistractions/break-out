using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class IntroUI : MonoBehaviour
{
    public GameObject gameManager;
    public TMP_InputField userName;
    public TMP_Text highScoreText;

    public void Start()
    {
        GameManager.Instance.LoadScore();
        userName.text = GameManager.Instance.userName;
        if(GameManager.Instance.score > 0)
        {
            highScoreText.text = "Current High Score belongs to " + GameManager.Instance.topUserName + " with a score of " + GameManager.Instance.score;
        }
     
    }

    public void StartGame()
    {
        GameManager.Instance.userName = userName.text;
        SceneManager.LoadScene(1);
    }

    public void ExitGame()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }


}
