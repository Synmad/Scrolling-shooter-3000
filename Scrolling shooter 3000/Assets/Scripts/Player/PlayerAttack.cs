using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerAttack : MonoBehaviour
{
    GameObject bullet;
    [SerializeField] GameObject bulletSpawner;
    public static Action onPlayerAttack;

    private void OnEnable()
    {
        onPlayerAttack += SpawnBullet;
    }

    void Shoot(InputAction.CallbackContext callbackcontext)
    {
        if (callbackcontext.performed) { onPlayerAttack?.Invoke(); }
    }

    void SpawnBullet()
    {
        bullet = PlayerBulletPool.Instance.GetPooledObjects();
        
        if (bullet != null)
        {
            bullet.transform.position = bulletSpawner.transform.position;
            bullet.SetActive(true);
        }
    }

    private void OnDisable()
    {
        onPlayerAttack -= SpawnBullet;
    }
}
