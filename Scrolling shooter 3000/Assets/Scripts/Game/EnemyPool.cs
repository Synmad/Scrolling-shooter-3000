using System.Collections.Generic;
using UnityEngine;

public class EnemyPool : MonoBehaviour
{
    [SerializeField] GameObject enemyPrefab;
    [SerializeField] List<GameObject> pooledEnemies;

    [SerializeField] int poolSize;

    public static EnemyPool Instance { get; private set; }
    private void Awake()
    {
        Singleton();
        CreatePool();
    }

    void Singleton()
    {
        if (Instance != null && Instance != this) { Destroy(this); }
        else { Instance = this; }
    }

    void CreatePool()
    {
        pooledEnemies = new List<GameObject>();
        GameObject bullet;

        for (int i = 0; i < poolSize; i++)
        {
            bullet = Instantiate(enemyPrefab);
            bullet.SetActive(false);
            pooledEnemies.Add(bullet);
        }
    }

    public GameObject GetPooledEnemies()
    {
        for (int i = 0; i < poolSize; i++) { if (!pooledEnemies[i].activeInHierarchy) { return pooledEnemies[i]; } }
        return null;
    }
}
