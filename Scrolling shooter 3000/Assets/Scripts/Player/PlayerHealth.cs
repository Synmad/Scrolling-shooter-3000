using System;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public static Action onPlayerDeath;

    public int curHealth { get; private set; }
    [SerializeField] int maxHealth;

    private void OnEnable()
    {
        PlayerCollision.OnPlayerHit += Damage;
        curHealth = maxHealth;
    }

    void Damage()
    {
        curHealth--;
        Debug.Log(curHealth);
        if(curHealth <= 0)
        {
            onPlayerDeath?.Invoke();
        }
    }

    public void Heal(int amount)
    {
        if(curHealth < maxHealth)
        {
            curHealth += amount;
        }
    }

    private void OnDisable()
    {
        PlayerCollision.OnPlayerHit -= Damage;
    }
}
