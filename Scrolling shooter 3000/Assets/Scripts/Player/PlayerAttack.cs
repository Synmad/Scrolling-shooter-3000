using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerAttack : MonoBehaviour
{
    GameObject bullet;
    [SerializeField] GameObject bulletSpawner;

    public void Shoot(InputAction.CallbackContext callbackcontext)
    {
        if (callbackcontext.performed) { SpawnBullet(); }
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
}
