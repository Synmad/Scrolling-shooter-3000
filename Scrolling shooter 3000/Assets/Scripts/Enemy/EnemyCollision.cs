using UnityEngine;

public class EnemyCollision : MonoBehaviour
{
    void OnBecameInvisible() { this.gameObject.SetActive(false); }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player")) { this.gameObject.SetActive(false); }
    }
}
