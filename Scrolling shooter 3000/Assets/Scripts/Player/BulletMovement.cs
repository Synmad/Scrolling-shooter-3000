using UnityEngine;

public class BulletMovement : MonoBehaviour
{
    [SerializeField] float speed;

    Vector2 direction = new Vector2(1, 0);
    Vector2 velocity;

    private void Update()
    {
        velocity = direction * speed;
    }

    private void FixedUpdate()
    {
        Vector2 pos = transform.position;
        pos += velocity * Time.fixedDeltaTime;
        transform.position = pos;
    }
}
