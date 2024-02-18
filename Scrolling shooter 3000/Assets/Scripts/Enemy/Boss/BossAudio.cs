using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAudio : MonoBehaviour
{
    [SerializeField] AudioSource arrival;
    [SerializeField] AudioSource chargingLaser;
    [SerializeField] AudioSource firingLaser;
    [SerializeField] AudioSource death1;
    [SerializeField] AudioSource death2;

    private void OnEnable()
    {
        BossArrivingState.onBossArriving += PlayArrival;
        BossController.onWallReached += StopArrival;
        BossAttackingState.onBossAttacking += PlayCharging;
        BossAttackingState.onBossFired += StopCharging;
        BossAttackingState.onBossFired += PlayFire;
        BossDamage.onBossDie += PlayDeath;
    }

    void PlayArrival() { arrival.Play(); }
    void StopArrival() { arrival.Stop(); }

    void PlayCharging() { chargingLaser.Play(); }
    void StopCharging() { chargingLaser.Stop(); }

    void PlayFire() { firingLaser.Play(); }

    void PlayDeath() { death1.Play(); death2.Play(); }

    private void OnDisable()
    {
        BossArrivingState.onBossArriving -= PlayArrival;
        BossController.onWallReached -= StopArrival;
        BossAttackingState.onBossAttacking -= PlayCharging;
        BossAttackingState.onBossFired -= StopCharging;
        BossAttackingState.onBossFired -= PlayFire;
        BossDamage.onBossDie -= PlayDeath;
    }
}
