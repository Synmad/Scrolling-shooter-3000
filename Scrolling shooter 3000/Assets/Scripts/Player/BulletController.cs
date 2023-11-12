using UnityEngine;

public class BulletController : MonoBehaviour
{
    void OnBecameInvisible() { this.gameObject.SetActive(false); }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy")) { this.gameObject.SetActive(false); }
    }
}
