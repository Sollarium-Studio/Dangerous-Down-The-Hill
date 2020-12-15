using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    [SerializeField] private string gameSceneName;
    public bool gameCredits;
    public bool gameMenu;
    public GameObject panelCredits;

    public GameObject panelMenu;

    public Text bestScore;
    //public GameObject creditsButton;

    public void inCredits()
    {
        if (gameCredits == false)
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
        if (PlayerPrefs.HasKey("BestScore"))
        {
            bestScore.text = $"BEST SCORE: {PlayerPrefs.GetFloat("BestScore")}";
        }
        else
        {
            bestScore.text = $"BEST SCORE: 0";
        }
    }

    public void backMenu()
    {
        inCredits();
    }

    public void Play()
    {
        SceneManager.LoadScene(gameSceneName);
    }

    public void Quit()
    {
        Application.Quit();
    }
}