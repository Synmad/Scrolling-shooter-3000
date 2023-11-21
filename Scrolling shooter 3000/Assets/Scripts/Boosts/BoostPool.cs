using System.Collections.Generic;
using UnityEngine;

public class BoostPool : MonoBehaviour
{
    [SerializeField] GameObject prefab;
    [SerializeField] List<GameObject> pooledObjects;

    [SerializeField] int poolSize;

    public static BoostPool Instance { get; private set; }

    private void Awake()
    {
        Singleton();
        CreatePool();
    }

    protected void CreatePool()
    {
        pooledObjects = new List<GameObject>();
        Boost boost;

        for (int i = 0; i < poolSize; i++)
        {
            boost = BoostFactory.Instance.Create("Speed", this.gameObject.transform.position); //cómo hago para poolear distintos tipos de boost a la vez?? tal vez no debería poolear
            boost.gameObject.SetActive(false);
            pooledObjects.Add(boost.gameObject);
        }
    }

    void Singleton()
    {
        if (Instance != null && Instance != this) { Destroy(this); }
        else { Instance = this; }
    }

    public GameObject GetPooledObjects()
    {
        for (int i = 0; i < poolSize; i++)
        { 
            if (!pooledObjects[i].activeInHierarchy) 
            { 
                return pooledObjects[i];
            } 
        }
        return null;
    }
}
