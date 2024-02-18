using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDisabler : MonoBehaviour
{
    void OnBecameInvisible() => gameObject.SetActive(false);
}
