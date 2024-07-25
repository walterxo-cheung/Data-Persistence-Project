using System.Collections;
using System.Collections.Generic;
using TMPro;

#if UNITY_EDITOR
using UnityEditor;
# endif
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    public InputField inputPlayerName;
    public TextMeshProUGUI bestScoreText;
    // private string playerName;
    // Start is called before the first frame update
    void Start()
    {
        MenuDataManager.Instance.LoadGameData();
        if (MenuDataManager.Instance != null)
        {
            bestScoreText.text = "Best Score : " + MenuDataManager.Instance.HighPlayerName
                 + " : " + MenuDataManager.Instance.HighScore;
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void StartGame()
    {
        string playerName = inputPlayerName.text;
        MenuDataManager.Instance.PlayerName = playerName;
        Debug.Log("Name " + playerName);
        SceneManager.LoadScene(1);
    }

    public void QuitGame()
    {
# if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
# else
        Application.Quit();
# endif

    }
}
