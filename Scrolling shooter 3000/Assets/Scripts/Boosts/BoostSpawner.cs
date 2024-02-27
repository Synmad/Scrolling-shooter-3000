using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum BoostType
{
    Health,
    Speed,
}

public class BoostSpawner : MonoBehaviour
{
    [SerializeField] BoostFactory boostFactory;

    public void SpawnRandomBoost(Vector3 position)
    {
        //random.range deberia ser (0, [tamaño de BoostType]), pero no se como hacer eso
        BoostType randomType = (BoostType)Random.Range(0, 2);
        GameObject boostToSpawn = boostFactory.CreateBoost(randomType, position);   
        Debug.Log(boostToSpawn.name);
    }
}
