using System.Collections;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] float spawnTime;
    [SerializeField] float timer;
    [SerializeField] GameObject enemyBoss;
    [SerializeField] WinCondition winCondition;

    Camera mainCam;
    float maxLeft, maxRight, yPos;
    void Start()
    {
        mainCam = Camera.main;
        StartCoroutine(SetBoundaries());
    }

    IEnumerator SetBoundaries()
    {
        yield return new WaitForSeconds(.4f);
        maxLeft = mainCam.ViewportToWorldPoint(new Vector2(.1f, 0)).x;
        maxRight = mainCam.ViewportToWorldPoint(new Vector2(.9f, 0)).x;

        yPos = mainCam.ViewportToWorldPoint(new Vector2(0, 1f)).y;

    }
    void Update()
    {
        timer += Time.deltaTime;
        if (timer > spawnTime)
        {
            SpawnEnemies();
            timer = 0;
        }
    }

    private void SpawnEnemies()
    {
        GameObject obj = EnemyObjPool.instance.GetEnemy();
        obj.SetActive(true);

        if (obj != null)
        {
            Vector2 spawnPos = new(Random.Range(maxLeft, maxRight), yPos);
            obj.transform.SetPositionAndRotation(spawnPos, Quaternion.identity);
        }
    }

    private void OnDisable()
    {
        if (!winCondition.canSpawnBoss) return;
        if (enemyBoss != null)
        {
            Vector2 spawnPos = mainCam.ViewportToWorldPoint(new(.5f, 1.2f));
            Instantiate(enemyBoss, spawnPos, Quaternion.identity);
        }
    }
}
