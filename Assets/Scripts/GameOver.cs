using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public Text points;

    public Text highscore;
    public void SetUp()
    {
        gameObject.SetActive(true);
        points.text = (int)PlayerPrefs.GetFloat("currPoints") + " Points";
        PlayerPrefs.SetFloat("currPoints", 0.0f);
        highscore.text = PlayerPrefs.GetInt("highScorePoints").ToString();
    }

    public void RestartButton ()
    {
        SceneManager.LoadScene("Game");
    }

    public void MainMenuButton()
    {
        SceneManager.LoadScene("Menu");
    }
}
