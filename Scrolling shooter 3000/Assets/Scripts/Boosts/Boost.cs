using UnityEngine;

public abstract class Boost : MonoBehaviour
{
    public abstract string boostName { get; }
    public abstract void Effect();

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player")) 
        { 
            Effect();
            this.gameObject.SetActive(false);
        }
    }
}
