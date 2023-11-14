using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    [SerializeField] GameObject prefab;
    [SerializeField] List<GameObject> pooledObjects;

    [SerializeField] int poolSize;

    private void Awake()
    {
        CreatePool();
    }

    void CreatePool()
    {
        pooledObjects = new List<GameObject>();
        GameObject objectInstance;

        for(int i = 0; i < poolSize; i++)
        {
            objectInstance = Instantiate(prefab);
            objectInstance.SetActive(false);
            pooledObjects.Add(objectInstance);
        }
    }

    public GameObject GetPooledObjects()
    {
        for (int i = 0; i < poolSize; i++) { if (!pooledObjects[i].activeInHierarchy) { return pooledObjects[i]; } }
        return null;
    }
}
