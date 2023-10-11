using UnityEngine;

public class BulletController : MonoBehaviour
{
    void OnBecameInvisible() { this.gameObject.SetActive(false); }
}
