using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class ScoreDisplay : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI scoreText, highScoreText;
    void Start()
    {
        int score = PlayerPrefs.GetInt("Score" + SceneManager.GetActiveScene().name, 0);
        scoreText.text ="Score: "+ score.ToString();

        int highScore = PlayerPrefs.GetInt("HighScore" + SceneManager.GetActiveScene().name, 0);
        highScoreText.text ="HighScore: "+ highScore.ToString();
    
    }

    void Update()
    {
        
    }
}
