using System;
using UnityEngine;

public class PlayerDamage : MonoBehaviour
{
    public static Action onPlayerDeath;

    [SerializeField] int health;

    private void Awake()
    {
        PlayerCollision.onPlayerHit += Damage;
    }

    void Damage()
    {
        health--;
        if(health <= 0)
        {
            onPlayerDeath?.Invoke();
        }
    }
}
