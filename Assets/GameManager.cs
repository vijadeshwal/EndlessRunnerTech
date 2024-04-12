using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public int currentScore = 0;
    public int bestScore = 0;
    [SerializeField] Animator _playerAnimator;

    [HideInInspector] public UIManager _UIManager;

    public bool isGameOver = false;
    [SerializeField]
    private float currentGameSpeed = 1.0f; // Current game speed
    private float maxGameSpeed = 1.5f; // Maximum game speed
    private float speedIncreaseRate = 0.01f; // Rate at which game speed increases per second

    [SerializeField] TextMeshProUGUI _scoreText;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
            Instance = this;
        }

        _UIManager = GetComponent<UIManager>();
        Time.timeScale = 1f;
    }

    private void Start()
    {
        
        bestScore = PlayerPrefs.GetInt("BestScore", 0); ;
    }

    private void Update()
    {
        if (isGameOver)
        {
            Time.timeScale = 0f;
        }

        currentGameSpeed = Time.timeScale;
    }

    public void StartGame()
    {
        StartGameSpeedIncrease(); // Start increasing game speed
        _UIManager.ShowInGameUI();
        _playerAnimator.SetTrigger("Run");
        PlayerMovement _player = _playerAnimator.gameObject.GetComponentInParent<PlayerMovement>();
        _player.isRunning = true;
        StartCoroutine(CountAndIncreaseScore());
    }

    private IEnumerator CountAndIncreaseScore()
    {
        while (true)
        {
            yield return new WaitForSeconds(1f);

            currentScore++;
            UpdateScoreText();
        }
    }

    private void UpdateScoreText()
    {
        _scoreText.text = currentScore.ToString();
    }

    public void GameisOver()
    {
        isGameOver = true;
        StopGameSpeedIncrease(); // Stop increasing game speed
        _UIManager.ShowGameOverUI();
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    private void StartGameSpeedIncrease()
    {
        StartCoroutine(IncreaseGameSpeed());
    }

    private void StopGameSpeedIncrease()
    {
        StopCoroutine(IncreaseGameSpeed());
    }

    private IEnumerator IncreaseGameSpeed()
    {
        while (currentGameSpeed < maxGameSpeed)
        {
            yield return new WaitForSeconds(1f);
            currentGameSpeed += speedIncreaseRate; // Increase game speed
            Time.timeScale = currentGameSpeed; // Update time scale
        }
    }
}