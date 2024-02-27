using UnityEngine;

public static class ExplosionManager
{
    static GameObject explosion;

    public static void SpawnExplosion(Vector2 position)
    {
        explosion = ExplosionPooler.Instance.GetPooledObjects();
        explosion.SetActive(true); explosion.transform.position = position;
    }

    
}
