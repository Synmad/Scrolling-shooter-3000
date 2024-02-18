using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class EnemyDamage : MonoBehaviour
{
    [SerializeField] protected int health;

    public static Action onEnemyDie;

    public virtual void TakeDamage()
    {
        health--;
        if(health <= 0)
        {
            onEnemyDie?.Invoke();
            this.gameObject.SetActive(false);
        }
    }
}
