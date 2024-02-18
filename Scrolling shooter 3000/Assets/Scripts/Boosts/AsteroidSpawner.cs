using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidSpawner : MonoBehaviour
{
    [SerializeField] GameObject asteroidPrefab;
    [SerializeField] Transform[] spawnLocations;
    [SerializeField] float spawnCooldown;
        
    private void Start()
    {
        StartCoroutine(Spawn());
    }

    IEnumerator Spawn()
    {
        while (true)
        {
            Instantiate(asteroidPrefab, (spawnLocations[Random.Range(0, spawnLocations.Length)].position), Quaternion.identity);
            yield return new WaitForSeconds(spawnCooldown);
        }
    }
}
