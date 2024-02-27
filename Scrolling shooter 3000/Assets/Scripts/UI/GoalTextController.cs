using TMPro;
using UnityEngine;

public class GoalTextController : MonoBehaviour
{
    int enemiesRemaining;

    TextMeshProUGUI text;

    private void OnEnable()
    {
        GoalController.onGoalReached += DisableText;
        EnemyDamage.onEnemyDie += DecreaseEnemiesRemaining;
    }

    private void Awake()
    {
        text = GetComponent<TextMeshProUGUI>();
    }

    private void Start()
    {
        enemiesRemaining = GoalController.Instance.goal;
        UpdateText();
    }

    void DecreaseEnemiesRemaining()
    {
        enemiesRemaining--;
        UpdateText();
    }

    void UpdateText() => text.text = "ENEMIES REMAINING: " + enemiesRemaining.ToString();

    void DisableText()
    {
        gameObject.SetActive(false);
    }

    private void OnDisable()
    {
        GoalController.onGoalReached -= DisableText;
        EnemyDamage.onEnemyDie -= DecreaseEnemiesRemaining;
    }
}
