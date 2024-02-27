using TMPro;
using UnityEngine;

public class GoalTextController : MonoBehaviour
{
    int enemiesRemaining;

    TextMeshProUGUI text;

    private void OnEnable()
    {
        enemiesRemaining = GoalController.Instance.goal;
        UpdateText();
        GoalController.onGoalReached += DisableText;
    }

    private void Awake()
    {
        EnemyDamage.onEnemyDie += DecreaseEnemiesRemaining;
        text = GetComponent<TextMeshProUGUI>();
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
    }
}
