using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipAudio : MonoBehaviour
{
    [SerializeField] AudioSource fire;
    [SerializeField] AudioSource hurt;
    [SerializeField] AudioSource dead;

    private void OnEnable()
    {
        ShipAttackingState.onEnemyShipAttack += PlayFire;
        EnemyDamage.onEnemyDie += PlayDead;
    }

    void PlayFire()
    {
        fire.Play(); 
    }

    void PlayDead()
    {
        dead.Play();
    }

    private void OnDisable()
    {
        ShipAttackingState.onEnemyShipAttack -= PlayFire;
        EnemyDamage.onEnemyDie -= PlayDead;
    }
}
