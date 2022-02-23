using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using UnityEngine.SceneManagement;

public class QuizScript : MonoBehaviour
{
    public QuestionsClass[] Facts;

    private static List<QuestionsClass> Used;

    private QuestionsClass currQ;

    [SerializeField] private Text QText;

    public GameOver gameOver;
    public void SetUp() 
    {
        gameObject.SetActive(true);

        if (Used == null || Used.Count == 0)
        {
            Used = Facts.ToList<QuestionsClass>();
        }

        LoadQuestion();
    }

    private void LoadQuestion()
    {
        int currQindex = Random.Range(0, Used.Count);
        currQ = Used[currQindex];

        QText.text = currQ.question;

        Used.RemoveAt(currQindex);
    }

    public void TrueAnswer()
    {
        if (currQ.isTrue)
        {
            SceneManager.LoadScene("Game");
        } else 
        {
            gameObject.SetActive(false);
            gameOver.SetUp();
        }
    }

    public void FalseAnswer()
    {
        if (!currQ.isTrue)
        {
            SceneManager.LoadScene("Game");
        } else 
        {
            gameObject.SetActive(false);
            gameOver.SetUp();
        }
    }
}
