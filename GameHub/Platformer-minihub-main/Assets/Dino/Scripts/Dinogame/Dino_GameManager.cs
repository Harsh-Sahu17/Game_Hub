using TMPro;
using UnityEngine;
using UnityEngine.UI;

[DefaultExecutionOrder(-1)]
public class Dino_GameManager : MonoBehaviour
{
    public static Dino_GameManager Instance { get; private set; }

    public float initialGameSpeed = 5f;
    public float gameSpeedIncrease = 0.1f;
    public float gameSpeed { get; private set; }

    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI hiscoreText;
    public GameObject gameOver;
    public GameObject getReady;
    public Button retryButton;
    public Button playButton;

    private Dino_Player player;
    private Dino_Spawner spawner;

    private float score;
    private bool gameStarted = false;

    private void Awake()
    {
        if (Instance != null)
        {
            DestroyImmediate(gameObject);
        }
        else
        {
            Instance = this;
        }
        UpdateHiscore();
    }

    private void OnDestroy()
    {
        if (Instance == this)
        {
            Instance = null;
        }
    }

    private void Start()
    {
        player = FindObjectOfType<Dino_Player>();
        spawner = FindObjectOfType<Dino_Spawner>();

        player.gameObject.SetActive(false);
        spawner.gameObject.SetActive(false);
        gameOver.gameObject.SetActive(false);
        getReady.gameObject.SetActive(true);
        retryButton.gameObject.SetActive(false);
        playButton.gameObject.SetActive(true);

        // Add listeners to the play and retry buttons
        playButton.onClick.AddListener(OnClickPlay);
        retryButton.onClick.AddListener(OnClickRetry);
    }

    public void NewGame()
    {
        Dino_Obstacles[] obstacles = FindObjectsOfType<Dino_Obstacles>();

        foreach (var obstacle in obstacles)
        {
            Destroy(obstacle.gameObject);
        }

        score = 0f;
        gameSpeed = initialGameSpeed;
        enabled = true;

        player.gameObject.SetActive(true);
        spawner.gameObject.SetActive(true);
        gameOver.gameObject.SetActive(false);
        getReady.gameObject.SetActive(false);
        retryButton.gameObject.SetActive(false);
        playButton.gameObject.SetActive(false);

    }

    public void GameOver()
    {
        gameSpeed = 0f;
        enabled = false;

        player.gameObject.SetActive(false);
        spawner.gameObject.SetActive(false);
        gameOver.gameObject.SetActive(true);
        retryButton.gameObject.SetActive(true);

        UpdateHiscore();
    }

    private void Update()
    {
        if (gameStarted)
        {
            gameSpeed += gameSpeedIncrease * Time.deltaTime;
            score += gameSpeed * Time.deltaTime;
            scoreText.text = Mathf.FloorToInt(score).ToString("D5");
        }
    }

    private void UpdateHiscore()
    {
        float hiscore = PlayerPrefs.GetFloat("hiscore", 0);

        if (score > hiscore)
        {
            hiscore = score;
            PlayerPrefs.SetFloat("hiscore", hiscore);
        }

        hiscoreText.text = Mathf.FloorToInt(hiscore).ToString("D5");
    }

    public void OnClickRetry()
    {
        NewGame();
    }

    public void OnClickPlay()
    {
        gameStarted = true;
        NewGame();
    }
}