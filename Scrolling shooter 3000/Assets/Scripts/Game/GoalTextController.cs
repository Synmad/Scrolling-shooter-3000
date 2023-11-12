using TMPro;
using UnityEngine;

public class GoalTextController : MonoBehaviour
{
    int enemiesRemaining;

    TextMeshProUGUI text;

    private void Awake()
    {
        EnemyCollision.onEnemyDie += DecreaseEnemiesRemaining;
        text = GetComponent<TextMeshProUGUI>();
    }

    private void Start()
    {
        enemiesRemaining = GoalController.Instance.goal;
        UpdateText();
    }

    void DecreaseEnemiesRemaining()
    {
        Debug.Log("el pepe");
        enemiesRemaining--;
        UpdateText();
    }

    void UpdateText()
    {
        text.text = "ENEMIES REMAINING: " + enemiesRemaining.ToString();
    }
}
