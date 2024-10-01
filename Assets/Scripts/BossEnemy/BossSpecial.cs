using System.Collections;
using UnityEngine;

public class BossSpecial : BossBaseState
{
    [SerializeField] private float speed;
    [SerializeField] private float waitTime;
    [SerializeField] private GameObject specialBullet;
    [SerializeField] private Transform shootingPoint;
    Vector2 targetPoint;
    protected override void Start()
    {
        targetPoint = mainCam.ViewportToWorldPoint(new Vector2(.5f, .9f));
    }

    public override void RunState()
    {
        StartCoroutine(nameof(RunSpecialState));
    }

    public override void StopState()
    {
        base.StopState();
    }

    IEnumerator RunSpecialState()
    {
        while (Vector2.Distance(targetPoint, transform.position) > .01f)
        {
            transform.position = Vector2.MoveTowards(transform.position, targetPoint, speed*Time.deltaTime);
            yield return new WaitForEndOfFrame();
        }
        Instantiate(specialBullet, shootingPoint.position, Quaternion.identity);
        yield return new WaitForSeconds(waitTime);
        bossController.ChangeState(BossState.Fire);
    }
    void Update()
    {
        
    }
}
