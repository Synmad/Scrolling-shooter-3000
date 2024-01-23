using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossIdleState : BossState
{
    float startingTime;
    float maxTime = 3;
    float currentTime;
    public override void EnterState(BossController boss)
    {
        Debug.Log("enter idle");
        currentTime = startingTime;
    }

    public override void UpdateState(BossController boss)
    {
        if (currentTime <= maxTime) { currentTime += 1 * Time.deltaTime; }
        else { boss.ChangeState(boss.moving); }
    }

    public override void ExitState(BossController boss) { Debug.Log("exit idle"); currentTime = startingTime; }
}
