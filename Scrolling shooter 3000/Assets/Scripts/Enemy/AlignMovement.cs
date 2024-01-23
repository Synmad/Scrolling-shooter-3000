using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlignMovement : Enemy
{
    [SerializeField] float speed;
    GameObject player;

    [SerializeField] GameObject rayOrigin;
    RaycastHit2D hit;

    [SerializeField] GameObject bulletSpawner;
    GameObject bullet;
    bool isAttacking;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void Update()
    {
        if(isAttacking == false)
        {
            transform.position = new Vector3(0, Mathf.Lerp(transform.position.y, player.transform.position.y, Time.deltaTime * speed));
        }
        

        hit = Physics2D.Raycast(rayOrigin.transform.position, Vector2.left);
        if (hit.collider != null)
        {
            if(hit.collider.gameObject.tag == "Player")
            {
                bullet = EnemyBulletPool.Instance.GetPooledObjects();

                if (bullet != null && isAttacking == false)
                {
                    StartCoroutine(Attack());
                }
                
            }
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
    
}
