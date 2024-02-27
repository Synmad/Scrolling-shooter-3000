using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BossFightSpawner : MonoBehaviour
{
    [SerializeField] GameObject enemyToSpawn;

    [SerializeField] BossController boss;
    [SerializeField] List<GameObject> spawners = new List<GameObject>();
    [SerializeField] List<Vector3> eligibleSpawners = new List<Vector3>();

    bool hasSpawned;

    private void Update()
    {
        if (!hasSpawned)
        {
            if (BossController.currentState == boss.attacking)
            {
                for (int i = 0; i < spawners.Count; i++)
                {
                    if (!spawners[i].activeInHierarchy)
                    {
                        continue;
                    }
                    eligibleSpawners.Add(spawners[i].transform.position);
                }
                Spawn();
                spawners.Clear();
                hasSpawned = true;
            }
        }
        
        if(BossController.currentState == boss.moving)
        {
            hasSpawned = false;
        }
    }

    void Spawn()
    {
        GameObject instance = Instantiate(enemyToSpawn);
        instance.transform.position = ChooseRandom();
    }

    Vector3 ChooseRandom()
    {
        int randomSpawn = Random.Range(0, eligibleSpawners.Count);
        Vector3 spawnChosen = eligibleSpawners[randomSpawn];
        return spawnChosen;
    }

    //private Vector3 charpos1 = new Vector3(x, y, z,);
    //private Vector3 charpos2 = new Vector3(x, y, z);
    //private List<Vector3> possiblePositions;
}
