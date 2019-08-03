using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class gameController : MonoBehaviour
{
    public GameObject[] hazards;
    public Vector3 spawnValues;
    public AudioSource background;
    public AudioSource win;
    public AudioSource loose;
    public Button normalMode;
    public Button timedMode;
    public Button hardMode;
    public int hazardCount;
    public int timeLeft;
    public float spawnWait;
    public float startWait;
    public float waveWait;
    public float speed;

    public Text ScoreText;
    public Text restartText;
    public Text gameOverText;
    public Text createdText;
    public Text timerText;
    
    public bool won;
    private bool gameOver;
    public bool timed;
    public bool normal;
    public bool hard;
    private bool restart;
    private int score;
    private int nextUpdate = 1;


    void Start()
    {
        gameOver = false;
        restart = false;
        timed = false;
        normal = true;
        hard = false;
        restartText.text = "";
        gameOverText.text = "";
        timerText.text = "Normal";
        createdText.text = "";
        score = 0;
        speed = -5f;
        UpdateScore();
        StartCoroutine(SpawnWaves());
        getAudio();
        background.Play(); 
    }
    void Update()
    {   getAudio();
        if (restart)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                SceneManager.LoadScene("Main");
                Normal();
                getAudio();
            }
        }
        if (Input.GetKey("escape"))
            Application.Quit();

        normalMode.onClick.AddListener(Normal);
        timedMode.onClick.AddListener(Timed);
        hardMode.onClick.AddListener(Hard);

        if (timed == true)
        {
            if(Time.time>=nextUpdate)
            {
             Debug.Log(Time.time+">="+nextUpdate);
             nextUpdate=Mathf.FloorToInt(Time.time)+1;
             timer1();
            }
        }
    }
   IEnumerator SpawnWaves()
    {
        yield return new WaitForSeconds(startWait);
        while (true)
        {
            for (int i = 0; i < hazardCount; i++)
            {
                GameObject hazard = hazards[Random.Range (0, hazards.Length)];
                Vector3 spawnPosition = new Vector3(Random.Range(-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
                Quaternion spawnRotation = Quaternion.identity;
                Instantiate(hazard, spawnPosition, spawnRotation);
                yield return new WaitForSeconds(spawnWait);
            }
            yield return new WaitForSeconds(waveWait);

            if (gameOver)
            {
                restartText.text = "Press 'Space' to Restart";
                restart = true;
                break;
            }
            
            
        }
    }

    public void AddScore(int newScoreValue)
    {
        score += newScoreValue;
        UpdateScore();
    }

    void UpdateScore()
     {
        ScoreText.text = "Points: " + score;
        if (score >= 100 && normal == true)
          {
            gameOverText.text = "You win!";
            gameOver = true;
            restart = true;
            normal = false;
            won = true;
            createdText.text = "Game created by Holden Elling!";
            background.Stop();
            win.Play();
            speed = -20.0f;
           }
        if (score >= 1000 && hard == true)
          {
            gameOverText.text = "You win!";
            gameOver = true;
            restart = true;
            hard = false;
            won = true;
            createdText.text = "Game created by Holden Elling!";
            background.Stop();
            win.Play();
            speed = -20.0f;
           }
      }

    public void GameOver()
    {
        gameOverText.text = "Game Over!";
        gameOver = true;
        background.Stop();
        loose.Play();
    }
    public void Timed()
    {
        score = 0;
        timeLeft = 30;
        timed = true;
        normal = false;
        hard = false;
        hazardCount = 10;
        spawnWait = .5f;
        waveWait = .5f;
        speed = -5.0f;
        timer1();
        UpdateScore();
    }
    public void Normal()
    {
        timerText.text = "Normal";
        timed = false;
        normal = true;
        hard = false;
        score = 0;
        hazardCount = 10;
        spawnWait = .5f;
        waveWait = 4;
        timeLeft = 30;
        speed = -5.0f;
        UpdateScore();
    }
    public void Hard()
    {
        score = 0;
        timerText.text = "Hard Mode";
        timed = false;
        normal = false;
        hard = true;
        hazardCount = 20;
        spawnWait = .3f;
        waveWait = 2;
        timeLeft = 30;
        speed = -10.0f;
        UpdateScore();
    }
    void getAudio()
    {
        var source = GetComponents<AudioSource>();
        background = source[0];
        loose = source[1];
        win = source[2];
        
    }
    void timer1()
{
    if (timeLeft > 0)
    {
        timeLeft = timeLeft - 1;
        timerText.text = timeLeft + " seconds";
    }
    else
    {
        timeLeft = 0;
        timerText.text = timeLeft + " seconds";
        gameOverText.text = "Out of Time!";
        gameOver = true;
        restart = true;
        timed = false;
        won = true;
        createdText.text = "Game created by Holden Elling!";
        background.Stop();
        win.Play();
    }
}
}

