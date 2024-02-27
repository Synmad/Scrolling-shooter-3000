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
    int maxHealth;

    [SerializeField] BossHealthBar healthBar;

    private void OnEnable()
    {
        maxHealth = health;
        healthBar.gameObject.SetActive(true);
        healthBar.SetUpBar(maxHealth);
    }

    public override void TakeDamage()
    {
        health--;
        healthBar.UpdateBar(health);
        onBossHurt?.Invoke();

        if(!halfHealth && health < maxHealth / 2 )
        {
            halfHealth = true;
        }

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