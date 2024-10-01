using System.Collections;
using UnityEngine;

public class BossEnter : BossBaseState
{
    [SerializeField] private float speed;
    Vector2 entryPoint;
    protected override void Start()
    {
        base.Start();
        entryPoint = mainCam.ViewportToWorldPoint(new Vector2(.5f, .7f));
    }

    public override void RunState()
    {
        StartCoroutine(nameof(RunEnterState));
    }

    public override void StopState()
    {
        base.StopState();
    }
    IEnumerator RunEnterState()
    {
        while (Vector2.Distance(entryPoint, transform.position) > .1f)
        {
            transform.position = Vector2.MoveTowards(transform.position, entryPoint, speed * Time.deltaTime);
            yield return new WaitForEndOfFrame();
        }
        bossController.ChangeState(BossState.Fire);

    }
    void Update()
    {
        
    }
}
