using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAttackingState : BossState
{
    float startingTime;
    float currentTime;
    float maxTime = 2;

    float laserDuration;

    public static Action onBossAttacking;
    public static Action onBossFired;

    BossController _boss;

    bool firing;
    public override void EnterState(BossController boss)
    {
        onBossAttacking?.Invoke();
        currentTime = startingTime;
        _boss = boss;
        onBossFired += Fire;
    }

    public override void ExitState(BossController boss)
    {
        Debug.Log("exit attacking");
    }

    public override void UpdateState(BossController boss)
    {
        if(firing == false)
        {
            if (currentTime < maxTime)
            {
                currentTime += 1 * Time.deltaTime;
            }

            if (currentTime >= maxTime)
            {
                onBossFired?.Invoke();
            }
        }
        
        if(firing == true) { laserDuration += 1 * Time.deltaTime; }

        if (laserDuration >= 3) { _boss.laser.SetActive(false); currentTime = startingTime; laserDuration = 0; _boss.ChangeState(_boss.idle); firing = false; }
    }

    void Fire()
    {
        firing = true;
        _boss.laser.SetActive(true);
    }
}
