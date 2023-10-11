using System.Collections.Generic;
using UnityEngine;

public class BulletPool : MonoBehaviour
{
    [SerializeField] GameObject bulletPrefab;
    [SerializeField] List<GameObject> pooledBullets;

    [SerializeField] int poolSize;

    public static BulletPool Instance { get; private set; }

    private void Awake()
    {
        if (Instance != null && Instance != this) { Destroy(this); }
        else { Instance = this; }

        pooledBullets = new List<GameObject>();
        GameObject bullet;

        for (int i = 0; i < poolSize; i++)
        {
            bullet = Instantiate(bulletPrefab);
            bullet.SetActive(false);
            pooledBullets.Add(bullet);
        }
    }

    public GameObject GetPooledBullets()
    {
        for (int i = 0; i < poolSize; i++) { if (!pooledBullets[i].activeInHierarchy) { return pooledBullets[i]; } }
        return null;
    }
}
