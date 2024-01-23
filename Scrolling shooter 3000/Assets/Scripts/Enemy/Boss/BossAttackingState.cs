using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAttackingState : BossState
{
    float startingTime;
    float currentTime;
    float maxTime = 2;

    float laserDuration;

    BossController _boss;
    public override void EnterState(BossController boss)
    {
        Debug.Log("enter attacking");
        currentTime = startingTime;
        _boss = boss;
    }

    public override void ExitState(BossController boss)
    {
        Debug.Log("exit attacking");
    }

    // carga durante x segundos para liberar un laser que ocupa todo el tercio de la pantalla en el que se encuentra
    public override void UpdateState(BossController boss)
    {
        if(currentTime < maxTime)
        {
            currentTime += 1 * Time.deltaTime;
        }

        if(currentTime >= maxTime)
        {
            boss.laser.SetActive(true);
            laserDuration += 1 * Time.deltaTime;
            if(laserDuration >= 3) { boss.laser.SetActive(false); currentTime = startingTime; laserDuration = 0; boss.ChangeState(boss.idle); }
        }
        
    }
}
