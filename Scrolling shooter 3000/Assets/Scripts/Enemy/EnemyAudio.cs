using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAudio : MonoBehaviour
{
    [SerializeField] AudioSource dead;
    [SerializeField] AudioSource hurt;

    void OnEnable()
    {
        EnemyDamage.onEnemyDie += PlayDead;
        EnemyCollision.onEnemyHurt += PlayHurt;
    }

    void PlayDead()
    {
        dead.Play();
    }

    void PlayHurt()
    {
        hurt.Play();
    }

    void OnDisable()
    {
        EnemyDamage.onEnemyDie -= PlayDead;
    }
}
