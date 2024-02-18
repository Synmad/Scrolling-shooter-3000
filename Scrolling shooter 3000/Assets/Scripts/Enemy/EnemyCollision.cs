using System;
using UnityEngine;

public class EnemyCollision : MonoBehaviour
{
    public static Action onEnemyHurt;
    string obstacle;

    private void Awake() => obstacle = "PlayerBullet";
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag(obstacle))
        {
            onEnemyHurt?.Invoke();
        }
    }
}
