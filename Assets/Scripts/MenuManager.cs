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
        bestScoreText.text = "Best score: " + DataManager.instance.saveData.topPlayerName + " : " + DataManager.instance.saveData.bestScore;
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

    public void InstertName(string name)
    {    
        DataManager.currentPlayerName = name;
    }
}
