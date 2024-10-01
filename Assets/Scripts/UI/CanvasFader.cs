using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CanvasFader : MonoBehaviour
{
    public static CanvasFader instance;
    [SerializeField] CanvasGroup canvasGroup;
    [SerializeField] private float changeValue;
    [SerializeField] private float waitTime;

    [SerializeField] private GameObject loadingScreen;
    [SerializeField] private Image loadingBar;

     public  bool fadeStarted=false;

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
    void Start()
    {
        canvasGroup=GetComponentInChildren<CanvasGroup>();
        StartCoroutine(nameof(FadeIn));
    }

    void Update()
    {

    }

    public void StartFadeOut(string levelName)
    {
        StartCoroutine(FadeOut(levelName));
    }

    IEnumerator FadeIn()
    {
        loadingScreen.SetActive(false);
            fadeStarted = false;
        while (canvasGroup.alpha >0)
        {
            if (fadeStarted) yield break;
            canvasGroup.alpha -= changeValue;
            yield return new WaitForSeconds(waitTime);
        }
    }

    IEnumerator FadeOut(string levelName)
    {
        if (fadeStarted) yield break;
        fadeStarted = true;
        while (canvasGroup.alpha < 1)
        {
            canvasGroup.alpha += changeValue;
            yield return new WaitForSeconds(waitTime);
        }
        AsyncOperation ao = SceneManager.LoadSceneAsync(levelName);
        ao.allowSceneActivation = false;
        loadingScreen.SetActive(true);
        loadingBar.fillAmount = 0;

        while (!ao.isDone)
        {
            loadingBar.fillAmount =Mathf.Lerp(loadingBar.fillAmount, ao.progress / .9f,10*Time.deltaTime);
            if (ao.progress == .9f)
            {
                ao.allowSceneActivation = true;
            }
           yield return null;
        }
        StartCoroutine(nameof(FadeIn));
    }

   
}
