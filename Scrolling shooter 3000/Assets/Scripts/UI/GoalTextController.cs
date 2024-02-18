using TMPro;
using UnityEngine;

public class GoalTextController : MonoBehaviour
{
    int enemiesRemaining;

    TextMeshProUGUI text;

    private void Awake()
    {
        EnemyDamage.onEnemyDie += DecreaseEnemiesRemaining;
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
}
