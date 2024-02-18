using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossDamage : EnemyDamage
{
    public static Action onBossDie;
    public static Action onVictory;

    public override void TakeDamage()
    {
        health--;
        if (health <= 0)
        {
            StartCoroutine(Die());
        }
    }

    IEnumerator Die()
    {
        onEnemyDie?.Invoke();
        GetComponent<BossController>().ChangeState(GetComponent<BossController>().dead);
        onBossDie?.Invoke();
        yield return new WaitForSeconds(3);
        onVictory?.Invoke();
        
    }
}