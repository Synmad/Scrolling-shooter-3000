using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipAudio : MonoBehaviour
{
    [SerializeField] AudioSource fire;

    private void OnEnable()
    {
        ShipAttackingState.onEnemyShipAttack += PlayFire;
    }

    void PlayFire()
    {
        fire.Play(); 
    }

    private void OnDisable()
    {
        ShipAttackingState.onEnemyShipAttack -= PlayFire;
    }
}
