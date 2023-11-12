using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    GameObject enemy;

    private void Update()
    {
        enemy = EnemyPool.Instance.GetPooledEnemies();
        if (enemy != null)
        { 
            enemy.transform.position = this.gameObject.transform.position;
            enemy.SetActive(true);
        }
    }
}
