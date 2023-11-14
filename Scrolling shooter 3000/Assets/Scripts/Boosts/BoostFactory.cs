using System.Collections.Generic;
using UnityEngine;

public class BoostFactory : MonoBehaviour
{
    [SerializeField] Boost[] boosts;

    Dictionary<string, Boost> boostsByName;

    private void Awake()
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
