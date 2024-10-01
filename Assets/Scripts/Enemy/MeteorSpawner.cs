using System.Collections;
using UnityEngine;

public class MeteorSpawner : MonoBehaviour
{
    [SerializeField] float spawnTime;
    [SerializeField] float timer;

    Vector2 spawnPos;
    float maxLeft, maxRight, yPos;
    Camera mainCam;
    void Start()
    {
        mainCam = Camera.main;
        StartCoroutine(nameof(SetCamBoundaries));
    }

    IEnumerator SetCamBoundaries()
    {
        yield return new WaitForSeconds(.4f);

        maxLeft = mainCam.ViewportToWorldPoint(new Vector2(.1f, 0)).x;
        maxRight = mainCam.ViewportToWorldPoint(new Vector2(.95f, 0)).x;

        yPos = mainCam.ViewportToWorldPoint(new Vector2(0, 1.1f)).y;
    }

    void Update()
    {

        timer += Time.deltaTime;
        if (timer > spawnTime)
        {
            SpawnMeteor();
            timer = 0;
        }

    }

    private void SpawnMeteor()
    {
        spawnPos = new Vector2(Random.Range(maxLeft, maxRight), yPos);
        GameObject meteor = MeteorObjPool.instance.GetMeteor();
        meteor.SetActive(true);

        if (meteor != null)
        {
            meteor.transform.SetPositionAndRotation(spawnPos, transform.rotation);
        }
    }


}
