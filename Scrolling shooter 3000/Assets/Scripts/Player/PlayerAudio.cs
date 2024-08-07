using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAudio : MonoBehaviour
{
    [SerializeField] AudioSource fire;
    [SerializeField] AudioSource hurt1;
    [SerializeField] AudioSource hurt2;

    private void OnEnable()
    {
        PlayerAttack.onPlayerAttack += PlayFire;
        PlayerCollision.OnPlayerHit += PlayHurt;
    }

    void PlayFire() { fire.Play(); }

    void PlayHurt() { hurt1.Play(); hurt2.Play(); }

    private void OnDisable()
    {
        PlayerAttack.onPlayerAttack -= PlayFire;
        PlayerCollision.OnPlayerHit -= PlayHurt;
    }
}
