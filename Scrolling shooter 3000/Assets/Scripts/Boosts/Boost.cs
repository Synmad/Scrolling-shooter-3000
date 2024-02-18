using UnityEngine;

public abstract class Boost : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            ApplyEffect(collision.gameObject);
            gameObject.SetActive(false);
        }
    }

    public abstract void ApplyEffect(GameObject target);
}
