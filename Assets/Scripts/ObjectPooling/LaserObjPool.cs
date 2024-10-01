using System.Collections.Generic;
using UnityEngine;

public class LaserObjPool : MonoBehaviour
{
    public static LaserObjPool instance;

    [SerializeField] private GameObject laserPrefab;
    [SerializeField] private List<GameObject> laserObject;
    [SerializeField] private int laserCount;

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
        for (int i = 0; i < laserCount; i++)
        {
            GameObject obj = Instantiate(laserPrefab, transform);
            obj.SetActive(false);
            laserObject.Add(obj);

        }
    }


    public GameObject GetLaser()
    {
        for (int i = 0; i < laserObject.Count; i++)
        {
            if (!laserObject[i].activeInHierarchy)
            {
                return laserObject[i];
            }
        }
        return null;
    }

}
