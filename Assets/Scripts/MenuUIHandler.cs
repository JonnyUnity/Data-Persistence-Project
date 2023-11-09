using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuUIHandler : MonoBehaviour
{
    [SerializeField]
    private TMPro.TextMeshProUGUI scoreText;
    [SerializeField]
    private TMPro.TMP_InputField nameText;

    private void Start()
    {
        scoreText.text = $"Best Score : {GameManager.Instance.HighScorePlayer} : {GameManager.Instance.HighScore}";
    }

    public void StartNew()
    {
        string name = nameText.text;
        if (string.IsNullOrEmpty(name))
        {
            name = "Player";
        }
        GameManager.Instance.CurrentPlayer = name;


        SceneManager.LoadScene(1);
    }



    public void Exit()
    {
        GameManager.Instance.Save();

#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif

    }

}
