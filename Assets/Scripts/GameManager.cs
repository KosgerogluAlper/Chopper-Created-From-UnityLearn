using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class GameManager : MonoBehaviour
{
    private Sensor sensor;

    [SerializeField] private GameObject titleScreen;
    [SerializeField] private List<GameObject> targets;

    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private TextMeshProUGUI gameOverText;
    [SerializeField] private TextMeshProUGUI liveText;

    [SerializeField] private GameObject pausePanel;
    [SerializeField] private Button restartButton;

    private bool isGameActive;
    public bool IsGameActive { get { return isGameActive; } set { isGameActive = value; } }

    private float spawnRate = 1.0f;
    private bool isPause = false;
    private int score;
    private void Awake()
    {
        sensor = GameObject.FindGameObjectWithTag("Sensor").GetComponent<Sensor>();
    }

    public void StartGame(float difficulty)
    {
        spawnRate = spawnRate / difficulty;
        titleScreen.gameObject.SetActive(false);
        isGameActive = true;
        score = 0;
        scoreText.text = "Score : " + score;
        StartCoroutine(SpawnTarget());
    }

    private void Update()
    {
        PauseShow();
    }

    private void PauseShow()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPause)
            {
                pausePanel.SetActive(false);
                Time.timeScale = 1.0f;
                isPause = false;
            }
            else
            {
                pausePanel.SetActive(true);
                Time.timeScale = 0f;
                isPause = true;
            }
        }
    }

    public void UpdateScore(int scoreToAdd)
    {
        score += scoreToAdd;
        scoreText.text = "Score: " + score;
    }

    public void LiveTextUI(int liveCount)
    {
        liveText.text = "Live: " + liveCount;
    }

    public void GameOver()
    {
        gameOverText.gameObject.SetActive(true);
        restartButton.gameObject.SetActive(true);
        isGameActive = false;
    }

    private IEnumerator SpawnTarget()
    {
        while (isGameActive)
        {
            yield return new WaitForSeconds(spawnRate);
            int index = Random.Range(0, targets.Count);
            Instantiate(targets[index]);
        }
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}