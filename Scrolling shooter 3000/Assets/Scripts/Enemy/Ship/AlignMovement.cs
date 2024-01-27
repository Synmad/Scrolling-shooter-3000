using System.Collections;
using UnityEngine;

public class AlignMovement : Enemy
{
    [SerializeField] float speed;
    GameObject player;

    [SerializeField] GameObject bulletSpawner;
    GameObject bullet;
    bool isAttacking;

    Vector2 targetPosition;

    bool overlapping;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void Update()
    {
        Vector2 velocity = new Vector2(1, 1) * speed;

        if(overlapping) { Debug.Log("mierdaaa"); }

        if(isAttacking == false)
        {
            targetPosition = new Vector2(transform.position.x, player.transform.position.y);
            if (Vector2.Distance(transform.position, targetPosition) < 0.1f)
            {
                bullet = EnemyBulletPool.Instance.GetPooledObjects();
                if (bullet != null)
                {
                    StartCoroutine(Attack());
                }
            }
            transform.position = Vector2.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
        }
    }
    
    IEnumerator Attack()
    {
        isAttacking = true;
        int attacksDone = 0;
        while (attacksDone <= 2)
        {
            bullet = EnemyBulletPool.Instance.GetPooledObjects();

            if (bullet != null)
            {
                bullet.transform.position = bulletSpawner.transform.position;
                bullet.SetActive(true);
            }
            attacksDone++;
            yield return new WaitForSeconds(0.5f);
        }
        isAttacking = false;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy")) { overlapping = true; }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy")) { overlapping = false; }
    }
}
