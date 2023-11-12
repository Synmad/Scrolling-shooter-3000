using System;
using UnityEngine;

public class EnemyCollision : MonoBehaviour
{
    public static Action onEnemyDie;

    void OnBecameInvisible() { this.gameObject.SetActive(false); }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            onEnemyDie?.Invoke();
            this.gameObject.SetActive(false);
        }
    }
}
