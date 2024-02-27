using UnityEngine;
using System;

public class EnemyDamage : MonoBehaviour
{
    [SerializeField] protected int curHealth;
    [SerializeField] protected int maxHealth;

    public static Action onEnemyDie;

    private void OnEnable()
    {
        curHealth = maxHealth;
    }

    public virtual void TakeDamage()
    {
        curHealth--;
        if(curHealth <= 0)
        {
            onEnemyDie?.Invoke();
            ExplosionManager.SpawnExplosion(transform.position);
            this.gameObject.SetActive(false);
        }
    }
}
