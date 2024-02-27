using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossDamage : EnemyDamage
{
    public static Action onBossHurt;
    public static Action onBossDie;
    public static Action onVictory;
    public bool halfHealth { get; private set; }

    [SerializeField] BossHealthBar healthBar;

    private void OnEnable()
    {
        healthBar.gameObject.SetActive(true);
        healthBar.SetUpBar(maxHealth);
    }

    public override void TakeDamage()
    {
        curHealth--;
        healthBar.UpdateBar(curHealth);
        onBossHurt?.Invoke();

        if(!halfHealth && curHealth < maxHealth / 2 )
        {
            halfHealth = true;
        }

        if (curHealth <= 0)
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