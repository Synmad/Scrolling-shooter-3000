using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] float amplitude;
    [SerializeField] float frequency;

    Vector2 pos;
    float center;

    private void Start() => center = EnemyPool.Instance.gameObject.transform.position.y;

    private void FixedUpdate()
    {
        pos = transform.position;

        pos.x -= speed * Time.fixedDeltaTime;

        float sin = Mathf.Sin(pos.x * frequency) * amplitude;
        pos.y = center + sin;

        transform.position = pos;
    }
}
