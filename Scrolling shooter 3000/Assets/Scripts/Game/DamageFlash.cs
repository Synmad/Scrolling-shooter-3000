using System.Collections;
using UnityEngine;

public class DamageFlash : MonoBehaviour
{
    [SerializeField] Material flashMaterial;
    [SerializeField] float flashDuration;

    SpriteRenderer spriteRenderer;
    Material originalMaterial;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        originalMaterial = spriteRenderer.material;
    }

    private void OnEnable()
    {
        spriteRenderer.material = originalMaterial;
    }

    public void StartFlash()
    {
        StartCoroutine(Flash());
    }

    IEnumerator Flash()
    {
        spriteRenderer.material = flashMaterial;
        yield return new WaitForSeconds(flashDuration);
        spriteRenderer.material = originalMaterial;
    }

}
