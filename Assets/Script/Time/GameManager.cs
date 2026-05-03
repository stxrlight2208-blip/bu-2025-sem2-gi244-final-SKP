using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public TMP_Text timeText;
    public TMP_Text bonusText;
    public TimeBonusManager bonusManager;

    public GameObject gameOverPanel;

    public float currentTime = 120f;

    private bool isGameOver = false;

    void Awake()
    {
        instance = this;
    }

    void Update()
    {
        if (isGameOver) return;

        currentTime -= Time.deltaTime;
        currentTime = Mathf.Max(currentTime, 0f);

        if (currentTime <= 0f)
        {
            GameOver();
        }

        UpdateUI();
    }

    void UpdateUI()
    {
        timeText.text = "Time: " + Mathf.CeilToInt(currentTime);
        bonusText.text = "Bonus: +" + Mathf.CeilToInt(bonusManager.currentBonus);
    }

    public void AddTime(float amount)
    {
        currentTime += amount;
    }

    void GameOver()
    {
        isGameOver = true;

        Time.timeScale = 0f;
        AudioListener.pause = true;

        gameOverPanel.SetActive(true);
    }

    public void RestartGame()
    {
        Time.timeScale = 1f;
        AudioListener.pause = false;

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}