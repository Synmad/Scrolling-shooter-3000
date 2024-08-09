using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerAttack : MonoBehaviour
{
    GameObject _bullet;
    [SerializeField] GameObject _bulletSpawner;
    [SerializeField] float _shootingCooldown;
    public static Action OnPlayerShoot;
    bool _isShooting;
    float _shootingTimer;

    private void OnEnable()
    {
        OnPlayerShoot += SpawnBullet;
    }

    private void Start()
    {
        _shootingTimer = _shootingCooldown;
    }

    void Shoot(InputAction.CallbackContext callbackContext)
    {
        if (callbackContext.performed) { _isShooting = true; }
        else if (callbackContext.canceled) { _isShooting = false; }
    }

    private void Update()
    {
        if (_isShooting) { _shootingTimer -= Time.deltaTime; }
        if (_shootingTimer <= 0) 
        {
            OnPlayerShoot?.Invoke();
            _shootingTimer = _shootingCooldown;
        }
    }

    void SpawnBullet()
    {
        _bullet = PlayerBulletPool.Instance.GetPooledObjects();
        
        if (_bullet != null)
        {
            _bullet.transform.position = _bulletSpawner.transform.position;
            _bullet.SetActive(true);
        }
    }

    private void OnDisable()
    {
        OnPlayerShoot -= SpawnBullet;
    }
}
