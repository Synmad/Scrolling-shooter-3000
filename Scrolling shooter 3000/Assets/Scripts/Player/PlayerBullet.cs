using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullet : Bullet
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Asteroid")) { this.gameObject.SetActive(false); }
        if (collision.gameObject.CompareTag("Enemy")) { this.gameObject.SetActive(false); collision.GetComponent<EnemyDamage>().TakeDamage(); }
    }
}
