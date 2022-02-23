using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public Text score;

    private void Awake() {
        score.text = PlayerPrefs.GetInt("highScorePoints", 0).ToString();
    }
    public void ExitButton(){
        Application.Quit();
    }

    public void StartButton(){
        SceneManager.LoadScene("Game");
    }
}
