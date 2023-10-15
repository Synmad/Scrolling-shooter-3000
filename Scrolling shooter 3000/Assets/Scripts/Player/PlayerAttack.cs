using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerAttack : MonoBehaviour
{
    GameObject bullet;
    [SerializeField] GameObject bulletSpawner;

    Rigidbody2D bulletRB;

    [SerializeField] float attackForce;

    public void Shoot(InputAction.CallbackContext callbackcontext)
    {
        if (callbackcontext.performed) { SpawnBullet(); }
    }

    void SpawnBullet()
    {
        bullet = BulletPool.Instance.GetPooledBullets();
        
        if (bullet != null)
        {
            bulletRB = bullet.GetComponent<Rigidbody2D>();
            bullet.transform.position = bulletSpawner.transform.position;
            bullet.SetActive(true);
            bulletRB.AddForce(bullet.transform.up * attackForce, ForceMode2D.Impulse);
        }
    }
}
