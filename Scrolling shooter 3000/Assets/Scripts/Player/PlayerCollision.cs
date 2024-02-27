using System;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    public static Action onPlayerHit;

    float timer = 0.8f;
    float timeLeft;

    private void Awake()
    {
        timeLeft = timer;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy")
        || collision.gameObject.CompareTag("EnemyBullet") 
        || collision.gameObject.CompareTag("Asteroid"))
        {
            onPlayerHit?.Invoke();
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy")
        || collision.gameObject.CompareTag("EnemyBullet"))
        {
            timeLeft -= Time.deltaTime;
            if (timeLeft <= 0)
            {
                onPlayerHit?.Invoke();
                timeLeft = timer;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        timeLeft = timer;
    }
}
