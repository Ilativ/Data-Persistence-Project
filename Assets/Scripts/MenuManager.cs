using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class MenuManager : MonoBehaviour
{
    public TextMeshProUGUI bestScoreText;
    //public TextMeshProUGUI inputFieldText;

    // Start is called before the first frame update
    void Start()
    {
        ////Set best score text and name
        Player bestPlayer = DataManager.instance.saveData.GetBestPlayer();
        bestScoreText.text = "Best score: " + bestPlayer.playerName + " : " + bestPlayer.bestScore;
    }

    public void StartGame()
    {
        SceneManager.LoadScene("main");
    }

    public void ExitGame()
    {
        //DataManager.instance.Save();
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif        
    }

    public void OpenHighScore()
    {
        SceneManager.LoadScene("high score");
    }

    public void InstertName(string name)
    {    
        DataManager.currentPlayer.playerName = name;
    }
}
