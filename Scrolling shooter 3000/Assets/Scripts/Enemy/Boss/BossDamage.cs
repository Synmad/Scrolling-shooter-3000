using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossDamage : EnemyDamage
{
    public static Action onBossHurt;
    public static Action onBossDie;
    public static Action onVictory;

    [SerializeField] BossHealthBar healthBar;

    private void OnEnable()
    {
        healthBar.gameObject.SetActive(true);
        healthBar.SetUpBar(health);
    }

    public override void TakeDamage()
    {
        health--;
        healthBar.UpdateBar(health);
        onBossHurt?.Invoke();
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