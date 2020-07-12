using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public static GameController instance;

    [SerializeField] private double score;
    [SerializeField] private GameObject gameOverPanel;
    [SerializeField] private TextMeshProUGUI scoreText;

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
