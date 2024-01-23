using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPooler : MonoBehaviour
{
    //[SerializeField] float countdown;

    [SerializeField] List<Queue> queues;

    [SerializeField] public Wave[] waves;
    int currentWave;
    public static Action onPoolingComplete;

    int currentQueue;
    

    private void Start()
    {
        queues = new List<Queue>();
        SpawnWave();
        SpawnQueue();
    }

    private void Update()
    {
        //countdown -= Time.deltaTime;
        //if(countdown <= 0)
        //{
        //    countdown = waves[currentWave].waveCooldown;
        //}
    }

    void SpawnWave()
    {
        for(int waveIndex = 0; 
            waveIndex < waves.Length;
            waveIndex++)
        {
            Queue queue = new Queue();
            queue.qEnemies = new List<GameObject>();
            queues.Add(queue);

            for (int enemyIndex = 0;
                enemyIndex < waves[currentWave].enemies.Count;
                enemyIndex++)
            {
                GameObject instance = Instantiate(waves[currentWave].enemies[enemyIndex]).gameObject;
                queue.qEnemies.Add(instance);
                instance.SetActive(false);
            }
            if(currentWave < waves.Length)
            {
                currentWave++;
            }
        }
    }

    void SpawnQueue()
    {
        for(int queueIndex = 0; 
            queueIndex <= queues.Count;
            queueIndex++)
        {
            for(int enemyIndex = 0;
                enemyIndex < queues[currentQueue].qEnemies.Count; 
                enemyIndex++)
            {
                queues[currentQueue].qEnemies[enemyIndex].SetActive(true);
                Debug.Log(queues[currentQueue].qEnemies[enemyIndex].name);
            }
            if (currentQueue < queues.Count)
            {
                currentQueue++;
            }
        }
    }
}

[System.Serializable]
public class Wave
{
    public List<Enemy> enemies;
    //public float spawnCooldown;
    //public float waveCooldown;
}

[System.Serializable]
public class Queue
{
    public List<GameObject> qEnemies;
}
