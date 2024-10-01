using UnityEngine;

public class BossDeath : BossBaseState
{

    public override void RunState()
    {
        EndGameManager.instance.StartResolveGameSequence();
        gameObject.SetActive(false);
    }

    
}
