using System;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    public static Action OnPlayerHit;
    [SerializeField] float _cameraShakeIntensity;
    [SerializeField] float _cameraShakeDuration;

    float _timer = 0.8f;
    float _timeLeft;

    private void Awake()
    {
        _timeLeft = _timer;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy")
        || collision.gameObject.CompareTag("EnemyBullet") 
        || collision.gameObject.CompareTag("Asteroid"))
        {
            OnPlayerHit?.Invoke();
            CameraShakeController.Instance.ShakeCamera(_cameraShakeIntensity, _cameraShakeDuration);
        }
    }
    
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy")
        || collision.gameObject.CompareTag("EnemyBullet"))
        {
            _timeLeft -= Time.deltaTime;
            if (_timeLeft <= 0)
            {
                OnPlayerHit?.Invoke();
                _timeLeft = _timer;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        _timeLeft = _timer;
    }
}
