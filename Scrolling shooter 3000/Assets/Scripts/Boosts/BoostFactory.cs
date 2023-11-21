using System.Collections.Generic;
using UnityEngine;

public class BoostFactory : MonoBehaviour
{
    [SerializeField] Boost[] boosts;

    public static BoostFactory Instance { get; private set; }

    Dictionary<string, Boost> boostsByName;

    private void Awake()
    {
        Singleton();
        PopulateDictionary();
    }

    void Singleton()
    {
        if (Instance != null && Instance != this) { Destroy(this); }
        else { Instance = this; } 
    }

    void PopulateDictionary()
    {
        boostsByName = new Dictionary<string, Boost>();

        foreach (var boost in boosts)
        {
            boostsByName.Add(boost.boostName, boost);
        }
    }

    public Boost Create (string boostName, Vector2 location)
    {
        if(!boostsByName.TryGetValue(boostName, out var boost))
        {
            Debug.Log($"El boost: { boostName } no existe");
        }

        return Instantiate(boost, location, Quaternion.identity);
    }
}
