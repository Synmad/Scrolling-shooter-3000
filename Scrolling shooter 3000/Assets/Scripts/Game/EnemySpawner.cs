using System.Collections;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] float cooldown;
    GameObject enemy;

    private void Start() { StartCoroutine(SpawnEnemy()); }

    private IEnumerator SpawnEnemy()
    {
        while (true)
        {
            enemy = EnemyPool.Instance.GetPooledObjects();
            if (enemy != null)
            {
                enemy.transform.position = this.gameObject.transform.position;
                enemy.SetActive(true);
            }
            yield return new WaitForSeconds(cooldown);
            yield return null;
        }
    }
}
