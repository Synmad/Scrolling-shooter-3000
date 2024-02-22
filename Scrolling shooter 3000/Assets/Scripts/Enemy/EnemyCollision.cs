using System;
using UnityEngine;

public class EnemyCollision : MonoBehaviour
{
    public static Action onEnemyHurt;
    string obstacle;
    DamageFlash damageFlash;

    private void Awake()
    {
        obstacle = "PlayerBullet";
        damageFlash = GetComponent<DamageFlash>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag(obstacle))
        {
            damageFlash.StartFlash();
            onEnemyHurt?.Invoke();
        }
    }
}
