using UnityEngine;


public enum BossState
{
    Enter, Fire, Special, Death
}

public class BossController : MonoBehaviour
{
    [SerializeField] private BossEnter bossEnter;
    [SerializeField] private BossFire bossFire;
    [SerializeField] private BossSpecial bossSpecial;
    [SerializeField] private BossDeath bossDeath;
    [SerializeField] private BossState bossState;

    [SerializeField] private bool test;

    [SerializeField] PlayerStats playerStats;

    private void Start()
    {
        playerStats = FindObjectOfType<PlayerStats>();
        ChangeState(BossState.Enter);
        if (test)
            ChangeState(bossState);
    }
    void Update()
    {

    }

    public void ChangeState(BossState state)
    {
        if (playerStats==null)
        {
            EndGameManager.instance.StartResolveGameSequence();
            return;
        }
        switch (state)
        {
            case BossState.Enter:
                bossEnter.RunState();
                break;
            case BossState.Fire:
                bossFire.RunState();
                break;
            case BossState.Special:
                bossSpecial.RunState();
                break;
            case BossState.Death:
                bossEnter.StopState();
                bossFire.StopState();
                bossSpecial.StopState();
                bossDeath.RunState();
                break;
            default: break;
        }
    }
}
