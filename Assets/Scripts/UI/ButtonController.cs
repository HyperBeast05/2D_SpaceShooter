using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonController : MonoBehaviour
{

    public void LoadNextLevel(string levelName)
    {
       CanvasFader.instance.StartFadeOut(levelName);
    }

    public void RestartLevel()
    {
        CanvasFader.instance.StartFadeOut(SceneManager.GetActiveScene().name);
    }

  
    void Start()
    {
        
    }

    void Update()
    {
        
    }
}
