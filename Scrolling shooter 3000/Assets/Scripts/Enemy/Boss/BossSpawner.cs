using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossSpawner : MonoBehaviour
{
    [SerializeField] GameObject boss;

    private void OnEnable()
    {
        GoalController.onGoalReached += Spawn;
    }

    void Spawn() { boss.SetActive(true); }

    private void OnDisable()
    {
        GoalController.onGoalReached -= Spawn;
    }
}
