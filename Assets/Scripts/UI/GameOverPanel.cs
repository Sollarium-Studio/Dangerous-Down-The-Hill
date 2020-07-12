using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverPanel : MonoBehaviour
{
    public static GameOverPanel instance;

    private void Awake()
    {
        if (!instance) instance = this;
        else Destroy(gameObject);
    }

    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private TMP_InputField nickInputField;
    [SerializeField] private Button backMenu;

    private void Start()
    {
        backMenu.onClick.AddListener(() => { SceneManager.LoadScene("Menu"); });

        scoreText.text = $"Score: {GameController.instance.GetScore():N0}";
    }
}