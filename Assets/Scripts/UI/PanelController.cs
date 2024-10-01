using UnityEngine;

public class PanelController : MonoBehaviour
{
    [SerializeField] CanvasGroup canvasGroup;
    [SerializeField] GameObject winScreen, looseScreen;

    private void Awake()
    {
    }
    void Start()
    {
        EndGameManager.instance.RegisterPanelController(this);        
    }

    void Update()
    {
        
    }

    public void ActivateWinScreen()
    {
        canvasGroup.alpha = 1f;
        winScreen.SetActive(true);
    }
    public void ActivateLooseScreen()
    {
        canvasGroup.alpha = 1f;
        looseScreen.SetActive(true);
    }
}
