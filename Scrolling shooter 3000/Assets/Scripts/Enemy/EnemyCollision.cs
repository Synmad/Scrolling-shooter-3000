using UnityEngine;

public class EnemyCollision : MonoBehaviour
{
    void OnBecameInvisible() { this.gameObject.SetActive(false); }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player")) { this.gameObject.SetActive(false); }
    }
}
