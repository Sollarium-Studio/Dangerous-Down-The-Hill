using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public bool gameCredits;
    public bool gameMenu;
    public GameObject panelCredits;
    public GameObject panelMenu;
    //public GameObject creditsButton;

    public void inCredits()
    {
        if(gameCredits == false)
        {
            gameCredits = true;
            gameMenu = false;
            panelCredits.SetActive(true);
            panelMenu.SetActive(false);
        }
        else
        {
            gameCredits = false;
            gameMenu = true;
            panelCredits.SetActive(false);
            panelMenu.SetActive(true);
        }
    }

    private void Start()
    {
        Time.timeScale = 1.0f;
    }

    public void backMenu()
    {
        inCredits();
    }

    public void Play()
    {
        SceneManager.LoadScene("SampleScene");
    }

    public void Quit()
    {
        Application.Quit();
    }

         
}
