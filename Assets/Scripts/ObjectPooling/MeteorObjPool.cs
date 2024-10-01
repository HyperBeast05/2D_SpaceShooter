using System.Collections.Generic;
using UnityEngine;

public class MeteorObjPool : MonoBehaviour
{
    public static MeteorObjPool instance;

    [SerializeField] private GameObject[] meteorPrefabs;
    [SerializeField] private List<GameObject> meteor;
    [SerializeField] private int meteorCount = 5;

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
        for (int i = 0; i < meteorCount; i++)
        {

            int randomMeteor = Random.Range(0, meteorPrefabs.Length);
            GameObject obj = Instantiate(meteorPrefabs[randomMeteor], transform);
            obj.SetActive(false);
            meteor.Add(obj);
        }

    }
    public GameObject GetMeteor()
    {
        for (int i = 0; i < meteor.Count; i++)
        {
            if (!meteor[i].activeInHierarchy)
            {
                return meteor[i];
            }
        }
        return null;
    }

    void Update()
    {

    }
}
