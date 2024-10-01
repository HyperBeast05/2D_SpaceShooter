using UnityEngine;

public class WinCondition : MonoBehaviour
{
    [SerializeField] private float possibleWinTime;
    [SerializeField] private GameObject[] spawners;
    [SerializeField] private bool hasBoss;

    public bool canSpawnBoss=false;

    private float timer;

    void Start()
    {

    }

    void Update()
    {
        if (EndGameManager.instance.gameOver)
        {
            DeactivatingSpawners();
            EndGameManager.instance.StartResolveGameSequence();
            gameObject.SetActive(false);
            return;
        }
        timer += Time.deltaTime;
        if (timer >= possibleWinTime)
        {
            if (!hasBoss)
            {
                EndGameManager.instance.StartResolveGameSequence();
            }
            else
            {
                canSpawnBoss = true;
            }
            DeactivatingSpawners();
            gameObject.SetActive(false);
        }
    }

    public void DeactivatingSpawners()
    {
        for (int i = 0; i < spawners.Length; i++)
        {
            spawners[i].SetActive(false);
        }
    }
}
