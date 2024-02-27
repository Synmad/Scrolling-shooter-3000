using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionPooler : ObjectPool
{
    public static ExplosionPooler Instance { get; private set; }

    private void Awake()
    {
        CreatePool();
        Singleton();
    }

    void Singleton()
    {
        if (Instance != null && Instance != this) { Destroy(this); }
        else { Instance = this; }
    }
}
