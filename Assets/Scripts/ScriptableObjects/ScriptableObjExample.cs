using UnityEngine;
using UnityEngine.SceneManagement;

[CreateAssetMenu(menuName = "ScriptableObj/PowerUpSpawner", fileName = "Spawner")]
public class ScriptableObjExample : ScriptableObject
{
    public GameObject[] spawners;
    public float spawnThreshold;

    public void SpawnerPowerUp(Vector2 spawnPos)
    {

        int randomChance = Random.Range(0, 100);
        if (randomChance > spawnThreshold)
        {
            int randomSpawner = Random.Range(0, spawners.Length);
            Instantiate(spawners[randomSpawner], spawnPos, Quaternion.identity);
        }
    }
}
