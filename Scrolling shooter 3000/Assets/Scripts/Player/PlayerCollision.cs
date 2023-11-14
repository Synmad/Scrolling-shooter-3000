using System;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    public static Action onPlayerHit;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy")) { onPlayerHit?.Invoke(); }
    }
}
