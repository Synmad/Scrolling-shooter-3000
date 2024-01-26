using System;
using UnityEngine;

public class EnemyCollision : MonoBehaviour
{
    public static Action onEnemyDie;
    string obstacle;

    private void Awake() => obstacle = "PlayerBullet";

    void OnBecameInvisible() => this.transform.parent.gameObject.SetActive(false);

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag(obstacle))
        {
            onEnemyDie?.Invoke();
            this.transform.parent.gameObject.SetActive(false);
        }
    }
}
