using System;
using UnityEngine;

public class GoalController : MonoBehaviour
{
    [field:SerializeField] public int goal { get; private set; }
    public static GoalController Instance { get; private set; }
    
    public int progress{ get; private set; }

    public static Action onGoalReached;

    private void Awake()
    {
        if (Instance != null && Instance != this) { Destroy(this); }
        else { Instance = FindAnyObjectByType<GoalController>(); }
    }

    private void OnEnable()
    {
        EnemyDamage.onEnemyDie += IncreaseProgress;
    }

    void IncreaseProgress()
    {
        progress++;
        if(progress == goal)
        {
            onGoalReached?.Invoke();
        }
    }

    private void OnDisable() => EnemyDamage.onEnemyDie -= IncreaseProgress;
}
