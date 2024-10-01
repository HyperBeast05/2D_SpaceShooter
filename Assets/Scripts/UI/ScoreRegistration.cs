using TMPro;
using UnityEngine;

public class ScoreRegistration : MonoBehaviour
{
    TextMeshProUGUI scoreText;
    void Start()
    {
        scoreText=GetComponent<TextMeshProUGUI>();
        scoreText.text = "Score: "+0;
        EndGameManager.instance.RegisterScoreText(scoreText);
    }

}
