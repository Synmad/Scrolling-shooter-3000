using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] float speed;

    [Tooltip("1 para moverla a la derecha, -1 para moverla a la izquierda")]
    [SerializeField] int direction;

    Vector2 directionVector;
    public Vector2 velocity;

    private void Awake() => directionVector = new Vector2(direction, 0);

    private void Update() => velocity = directionVector * speed;

    private void FixedUpdate()
    {
        Vector2 pos = transform.position;
        pos += velocity * Time.fixedDeltaTime;
        transform.position = pos;
    }

    void OnBecameInvisible() => this.gameObject.SetActive(false);
}
