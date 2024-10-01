using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyObjPool : MonoBehaviour
{
    public static EnemyObjPool instance;

    [SerializeField] private GameObject[] enemyPrefab;
    [SerializeField] private List<GameObject> enemyPool;
    [SerializeField] private int enemyCount;

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
        for (int i = 0; i < enemyCount; i++)
        {

            int randomEnemy = Random.Range(0, enemyPrefab.Length);
            GameObject enemy = Instantiate(enemyPrefab[randomEnemy], transform);
            enemy.SetActive(false);
            enemyPool.Add(enemy);
        }
    }



    public GameObject GetEnemy()
    {
        for (int i = 0; i < enemyPool.Count; i++)
        {
            if (!enemyPool[i].activeInHierarchy)
            {
                return enemyPool[i];
            }
        }
        return null;
    }


    void Update()
    {

    }
}
