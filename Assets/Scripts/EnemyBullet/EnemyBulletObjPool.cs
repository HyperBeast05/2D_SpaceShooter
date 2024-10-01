using System.Collections.Generic;
using UnityEngine;

public class EnemyBulletObjPool : MonoBehaviour
{
    public static EnemyBulletObjPool instance;

    [SerializeField] GameObject bulletPrefab;
    [SerializeField] List<GameObject> bulletPool;
    [SerializeField] int bulletCount;

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
        for (int i = 0; i < bulletCount; i++)
        {
            GameObject obj = Instantiate(bulletPrefab, transform);
            obj.SetActive(false);
            bulletPool.Add(obj);
        }
    }

    public GameObject GetBullet()
    {
        for (int i = 0; i < bulletPool.Count; i++)
        {
            if (!bulletPool[i].activeInHierarchy)
            {
                return bulletPool[i];
            }
        }
        return null;
    }

    void Update()
    {
        
    }
}
