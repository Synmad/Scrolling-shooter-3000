using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossSpawner : MonoBehaviour
{
    [SerializeField] GameObject boss;

    private void Awake()
    {
        GoalController.onGoalReached += Spawn;
    }

    void Spawn() { boss.SetActive(true); }
}
