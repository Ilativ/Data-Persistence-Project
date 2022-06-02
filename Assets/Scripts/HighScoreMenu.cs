using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class HighScoreMenu : MonoBehaviour
{
    public TextMeshProUGUI highScore;

    private void Start()
    {
        List<Player> p = DataManager.instance.saveData.GetSortedPlayerList();
        for (int I = 0; I < p.Count - 1; I++ )
        {
            highScore.text += "\n" + p[I].playerName + ": " + p[I].bestScore;
        }
    }

    public void GoToMainMenu()
    {
        Debug.Log("lol");
        SceneManager.LoadScene("menu");
    }
}
