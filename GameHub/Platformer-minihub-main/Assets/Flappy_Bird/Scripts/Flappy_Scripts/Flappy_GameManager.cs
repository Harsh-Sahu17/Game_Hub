using UnityEngine;
using UnityEngine.UI;

public class Flappy_GameManager : MonoBehaviour
{


    private int score;
    public Text scoreText;
    public Text highscoreText;
    public GameObject playButton;
    public Flappy_Player player;
    public GameObject gameOver;
    public GameObject getReady;
 //   public GameObject Settings;

    private void Awake()
    {
        Application.targetFrameRate = 60;
        Pause();
        UpdateHighScore();
        getReady.SetActive(true);
        gameOver.SetActive(false);
    }

    public void Play()
    {
        score = 0;
        scoreText.text = score.ToString();
        playButton.SetActive(false);
        gameOver.SetActive(false);
        getReady.SetActive(false);
        Time.timeScale = 1f;
        player.enabled = true;

        

        Pipes[] pipes = FindObjectsOfType<Pipes>();
        for (int i = 0; i < pipes.Length; i++)
        {
            Destroy(pipes[i].gameObject);
        }
        
    }

    public void Pause()
    {
        Time.timeScale = 0f;
        player.enabled = false;
    }

    public void GameOver()
    {
        gameOver.SetActive(true);
        playButton.SetActive(true);
        Pause();
        UpdateHighScore();
    }


    public void IncreaseScore()
    {
        score++;
        scoreText.text = score.ToString();
        
    }

    private void UpdateHighScore()
    {
        int highScore = PlayerPrefs.GetInt("highScore", 0);
        if(score > highScore)
        {
            highScore = score;
            PlayerPrefs.SetInt("highScore", highScore);

        }
        highscoreText.text = highScore.ToString();
    }


}

