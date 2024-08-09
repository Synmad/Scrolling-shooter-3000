using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionController : MonoBehaviour
{
    [SerializeField] float duration;

    private void OnEnable()
    {
        StartCoroutine(EndExplosion());   
    }

    IEnumerator EndExplosion()
    {
        yield return new WaitForSeconds(duration);
        gameObject.SetActive(false);
    }
}
