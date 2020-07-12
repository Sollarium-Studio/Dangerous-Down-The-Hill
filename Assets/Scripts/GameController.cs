using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public static GameController instance;

    [SerializeField] private double score;
    [SerializeField] private GameObject gameOverPanel;
    [SerializeField] private Text scoreText;

    private void Awake()
    {
        if (!instance) instance = this;
        else Destroy(gameObject);
    }

    public double GetScore()
    {
        return score;
    }

    public void GameOver()
    {
        gameOverPanel.SetActive(true);
        Time.timeScale = 0;
    }

    private void FixedUpdate()
    {
        if (Time.timeScale > 0)
        {
            score += 1;
        }

        scoreText.text = $"Score: {score:N0}";
    }
}