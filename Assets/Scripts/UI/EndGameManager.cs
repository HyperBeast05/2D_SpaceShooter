using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndGameManager : MonoBehaviour
{
    public static EndGameManager instance;

    private PanelController panelController;
    private LaserSpawner laserSpawner;

    private TextMeshProUGUI scoreText;

    public bool gameOver = false;

    int score=0;

    [HideInInspector]
    public string lvlUnlock = "lvlUnLock";


    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void UpdateScore(int addScore)
    {
        score += addScore;        
        scoreText.text = $"Score: {score}";       
    }

    public void SetScore()
    {
        PlayerPrefs.SetInt("Score"+SceneManager.GetActiveScene().name, score);
        int highScore = PlayerPrefs.GetInt("HighScore" + SceneManager.GetActiveScene().name, 0);

        if (score > highScore)
        {
            PlayerPrefs.SetInt("HighScore"+SceneManager.GetActiveScene().name,score);
        }
        score = 0;
    }

    public void StartResolveGameSequence()
    {
        StopCoroutine(nameof(ResolveGame));
        StartCoroutine(nameof(ResolveGame));
    }


    IEnumerator ResolveGame()
    {
        yield return new WaitForSeconds(2f);
        if (gameOver)
            LooseGame();
        else
        {
            WinGame();
            //laserSpawner.gameObject.SetActive(false);
            laserSpawner.enabled = false;
        }
    }

    private void WinGame()
    {
        SetScore();
        panelController.ActivateWinScreen();
        int nextlevlIndex = SceneManager.GetActiveScene().buildIndex + 1;
        if (nextlevlIndex > PlayerPrefs.GetInt(lvlUnlock, 0))
        {
            PlayerPrefs.SetInt(lvlUnlock, nextlevlIndex);
        }
    }

    private void LooseGame()
    {
        SetScore();
        panelController.ActivateLooseScreen();
    }
    public void RegisterPanelController(PanelController pc)
    {
        panelController = pc;
    }

    public void RegisterLaserSpawner(LaserSpawner spawner)
    {
        laserSpawner = spawner;
    }

    public void RegisterScoreText(TextMeshProUGUI text)
    {
        scoreText = text;
    }
    void Start()
    {

    }
    void Update()
    {

    }
}
