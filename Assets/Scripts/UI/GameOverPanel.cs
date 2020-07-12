using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace UI
{
    public class GameOverPanel : MonoBehaviour
    {
        public static GameOverPanel instance;

        private void Awake()
        {
            if (!instance) instance = this;
            else Destroy(gameObject);
        }

        [SerializeField] private Text scoreText;

        //[SerializeField] private TMP_InputField nickInputField;
        [SerializeField] private Button backMenu;
        [SerializeField] private Button playAgain;

        private void Start()
        {
            backMenu.onClick.AddListener(() => { SceneManager.LoadScene("Menu"); });
            playAgain.onClick.AddListener(() =>
            {
                Time.timeScale = 1.0f;
                SceneManager.LoadScene("SampleScene");
            });


            scoreText.text = $"Score: {GameController.instance.GetScore():N0}";
        }
    }
}