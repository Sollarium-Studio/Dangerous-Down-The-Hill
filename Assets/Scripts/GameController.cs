using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public static GameController instance;

    [SerializeField] private double score;
    [SerializeField] private GameObject gameOverPanel;
    [SerializeField] private Text scoreText;

    [SerializeField] private float dynamiteCount;
    [SerializeField] private GameObject dynamitePrefab;
    [SerializeField] private GameObject dynamiteIcon;
    [SerializeField] private Button dynamiteButton;

    [SerializeField] private GameObject player;

    private void Awake()
    {
        if (!instance) instance = this;
        else Destroy(gameObject);
    }

    private void Start()
    {
        dynamiteButton.onClick.AddListener(DynamiteButtonPressed);
    }

    public double GetScore()
    {
        return score;
    }

    public void GameOver()
    {
        gameOverPanel.SetActive(true);
        Time.timeScale = 0;
        SetActiveUI(false);

        if (PlayerPrefs.HasKey("BestScore"))
        {
            if (score > PlayerPrefs.GetFloat("BestScore"))
            {
                PlayerPrefs.SetFloat("BestScore", (float)score);
            }
        }
        else
        {
            PlayerPrefs.SetFloat("BestScore", (float)score);
        }
    }

    public void SetActiveUI(bool isActive)
    {
        dynamiteIcon.SetActive(isActive);
        scoreText.gameObject.SetActive(isActive);
    }

    private void FixedUpdate()
    {
        if (Time.timeScale > 0)
        {
            score += 1;
        }

        scoreText.text = $"Score: {score:N0}";

        if (dynamiteCount > 0)
            dynamiteIcon.SetActive(true);
        else
            dynamiteIcon.SetActive(false);
    }

    private void DynamiteButtonPressed()
    {
        dynamiteCount -= 1;
        Instantiate(dynamitePrefab, player.transform.position, dynamitePrefab.transform.rotation);
    }

    public void AddDynamite()
    {
        dynamiteCount += 1;
    }
}