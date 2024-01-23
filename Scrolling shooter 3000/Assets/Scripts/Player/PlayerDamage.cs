using System;
using UnityEngine;

public class PlayerDamage : MonoBehaviour
{
    PlayerShield shield;

    public static Action onPlayerDeath;

    private void Awake()
    {
        shield = this.gameObject.GetComponent<PlayerShield>();
        PlayerCollision.onPlayerHit += Damage;
    }

    void Damage()
    {
        //if (!shield.activated) { onPlayerDeath?.Invoke(); }
        //else { return; }
    }
}
