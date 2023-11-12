using UnityEngine;

public class BulletToggler : MonoBehaviour
{
    void OnBecameInvisible() { this.gameObject.SetActive(false); }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy")) { this.gameObject.SetActive(false); }
    }
}
