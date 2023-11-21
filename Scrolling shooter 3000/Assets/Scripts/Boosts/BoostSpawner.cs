using System.Collections;
using UnityEngine;

public class BoostSpawner : MonoBehaviour
{
    [SerializeField] float cooldown;
    GameObject boost;

    private void Start() => StartCoroutine(Spawn());

    private IEnumerator Spawn()
    {
        while (true)
        {
            boost = BoostPool.Instance.GetPooledObjects();
            if (boost != null)
            {
                boost.transform.position = this.gameObject.transform.position; //deber�a ser una posici�n aleatoria
                boost.SetActive(true);
            }
            yield return new WaitForSeconds(cooldown);
            yield return null;
        }
    }
}
