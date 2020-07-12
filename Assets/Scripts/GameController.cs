using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public static GameController instance;

    private void Awake()
    {
        if (!instance) instance = this;
        else Destroy(gameObject);
    }

    public void GameOver()
    {
        SceneManager.LoadScene("Menu");
    }
}
