using System;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    public static Action onPlayerHit;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy")) { onPlayerHit?.Invoke(); }
    }
}
