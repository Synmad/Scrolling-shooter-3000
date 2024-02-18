using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class AsteroidController : MonoBehaviour
{
    [SerializeField] BoostSpawner spawner;

    [SerializeField] float force;
    Rigidbody2D rb;

    string obstacle;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        obstacle = "PlayerBullet";
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(obstacle))
        {
            spawner.SpawnRandomBoost(transform.position);
            gameObject.SetActive(false);
        }
    }

    private void FixedUpdate()
    {
        rb.AddForce(new Vector2(0, 1) * force, ForceMode2D.Force);
        transform.Rotate(new Vector3(0,0,1) * Time.deltaTime);
    }
    //rb.AddForce(new Vector2(input.x, input.y) * force, ForceMode2D.Impulse); 
}
