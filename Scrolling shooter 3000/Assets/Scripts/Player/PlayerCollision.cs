using System;
using System.Collections;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    public static Action onPlayerHit;
    bool collidingWithEnemy;

    float timer = 0.8f;
    float timeLeft;

    private void Awake()
    {
        timeLeft = timer;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy") || collision.gameObject.CompareTag("EnemyBullet")) { Debug.Log("ENTER"); onPlayerHit?.Invoke(); }
        if (collision.gameObject.CompareTag("Boost")) { Debug.Log("boost!"); }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy") || collision.gameObject.CompareTag("EnemyBullet"))
        {
            timeLeft -= Time.deltaTime;
            if (timeLeft <= 0)
            {
                Debug.Log("STAY");
                onPlayerHit?.Invoke();
                timeLeft = timer;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        Debug.Log("EXIT");
        timeLeft = timer;
    }
}
