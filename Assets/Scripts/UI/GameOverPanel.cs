using Firebase;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverPanel : Singleton<GameOverPanel>
{
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private TMP_InputField nickInputField;
    [SerializeField] private Button backMenu;

    private void Start()
    {
        backMenu.onClick.AddListener(() =>
        {
            PostUser();
            
        });

        scoreText.text = $"Score: {GameController.instance.GetScore():N0}";
    }

    private void PostUser()
    {
        var score = GameController.instance.GetScore();
        var nick = nickInputField.text;

        UserScore userScore = new UserScore(nick, score);
        Firebase.Firebase.Instance.RegisterNewUser(userScore, () => SceneManager.LoadScene("Menu"),() => SceneManager.LoadScene("Menu"));
    }
}