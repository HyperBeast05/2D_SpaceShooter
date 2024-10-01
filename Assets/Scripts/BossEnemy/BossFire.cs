using System.Collections;
using UnityEngine;

public class BossFire : BossBaseState
{
    [SerializeField] private float speed;
    [SerializeField] private float shootRate;
    [SerializeField] private GameObject bulletPrefab;

    [SerializeField] private Transform[] shootPoints;
    Vector2 targetPoint;


    public override void RunState()
    {
        StartCoroutine(nameof(RunFireState));
    }

    public override void StopState()
    {
        base.StopState();
    }

    IEnumerator RunFireState()
    {
        float timer = 0;
        float fireStateTimer = 0;
        float fireStateExitTime = Random.Range(5f, 10f);
        targetPoint = new Vector2(Random.Range(maxLeft, maxRight), Random.Range(maxBottom, maxTop));

        while (fireStateTimer <= fireStateExitTime)
        {
            if (Vector2.Distance(targetPoint, transform.position) > .01f)
            {
                transform.position = Vector2.MoveTowards(transform.position, targetPoint, speed * Time.deltaTime);
            }
            else
            {
                targetPoint = new Vector2(Random.Range(maxLeft, maxRight), Random.Range(maxBottom, maxTop));
            }

            timer += Time.deltaTime;
            if (timer >= shootRate)
            {
                foreach (var item in shootPoints)
                {
                    SpawnBossBullet(item);
                }
                timer = 0;
            }
            yield return new WaitForEndOfFrame();
            fireStateTimer += Time.deltaTime;
        }
        bossController.ChangeState(BossState.Special);
    }

    private void SpawnBossBullet(Transform spwanPos)
    {
        GameObject bullet = EnemyBulletObjPool.instance.GetBullet();
        bullet.SetActive(true);
        if (bullet != null)
        {
            bullet.transform.SetPositionAndRotation(spwanPos.position, Quaternion.identity);
        }
    }

    void Update()
    {

    }
}
