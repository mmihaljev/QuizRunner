using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerScript : MonoBehaviour
{

    Rigidbody2D rb;

    public float moveSpeed;

    public float jumpHeight;

    public bool isGround = true;

    private float points;

    private float pointsSecond = 3.0f;

    public Text pointsText;

    public QuizScript Quiz;

    public GameObject quizscreen;

    private bool isAlive = true;

    private int highscore = 0;

    public Text countdown;
    

    private void Awake() {
        rb = GetComponent<Rigidbody2D>();
    }

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(countdownStart());
        highscore = PlayerPrefs.GetInt("highScorePoints", 0);
        points = PlayerPrefs.GetFloat("currPoints", 0);
    }


    IEnumerator countdownStart()
    {
        int timer = 3;
        while (timer < 0)
        {
            countdown.text = timer.ToString();
            yield return new WaitForSeconds(1f);
            timer--;
        }
        countdown.text = "GO";
        yield return new WaitForSeconds(1f);
        countdown.gameObject.SetActive(false);
    }
    // Update is called once per frame
    void Update()
    {
        if (isAlive == true)
        {
            points += pointsSecond * Time.deltaTime;
            pointsText.text = "" + (int)points;

            if(Input.GetMouseButton(0))
            {
                if(isGround == true)
                {
                    rb.velocity = Vector2.up * jumpHeight;
                    isGround = false;
                }
            }
        }
    }

    private void FixedUpdate() {
        if (isAlive == true)
        {
            rb.velocity = new Vector2(+moveSpeed, rb.velocity.y);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision) 
    {
        if (collision.gameObject.tag == "Floor")
        {
            isGround = true;
        }
        if (collision.gameObject.tag == "Danger")
        {
            if (highscore < (int)points)
            {
                PlayerPrefs.SetInt("highScorePoints", (int)points);
            }
            PlayerPrefs.SetFloat("currPoints", points);
            if (!quizscreen.activeSelf) Quiz.SetUp();
            isAlive = false;
        }
    }

}
