using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPooler : MonoBehaviour
{
    [SerializeField] public Wave[] waves;
    int currentWave;
    public static Action onPoolingComplete;

    [SerializeField] List<Queue> queues;
    [SerializeField] int currentQueue;

    bool spawningEnabled = true;

    void OnEnable()
    {
        GoalController.onGoalReached += StopSpawning;
    }

    void StopSpawning()
    {
        StopCoroutine(SpawnQueue());
        spawningEnabled = false;
        Debug.Log("stopped spawning");
    }

    private void Start()
    {
        queues = new List<Queue>();
        PoolWaves();
        StartCoroutine(SpawnQueue());
    }


    //Instantiates requested enemies, adds them to the queue, and disables them
    void PoolWaves()
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

    //Enables enemies in the queue
    IEnumerator SpawnQueue()
    {
        while (currentQueue < queues.Count - 1 && spawningEnabled)
        {
            for(int enemyIndex = 0;
                enemyIndex < queues[currentQueue].qEnemies.Count;
                enemyIndex++)
            {
                GameObject toSpawn;
                toSpawn = queues[currentQueue].qEnemies[enemyIndex];
                if(!toSpawn.activeInHierarchy && spawningEnabled)
                {
                    toSpawn.transform.position = waves[currentQueue].spawnPositions[enemyIndex].position;
                    toSpawn.SetActive(true);
                }
                yield return new WaitForSeconds(waves[currentQueue].timeBetweenEnemies);
            }
            currentQueue++;
            yield return new WaitForSeconds(waves[currentQueue].timeToNextWave);
            if(currentQueue == waves.Length - 1) { currentQueue = 0; }
        }
    }

    void OnDisable()
    {
        GoalController.onGoalReached -= StopSpawning;
    }
}

[System.Serializable]
public class Wave
{
    public List<Enemy> enemies;
    public Transform[] spawnPositions;
    public float timeBetweenEnemies;
    public float timeToNextWave;
}

[System.Serializable]
public class Queue
{
    public List<GameObject> qEnemies;
}
