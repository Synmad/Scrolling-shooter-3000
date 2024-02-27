using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverController : MonoBehaviour
{
    [SerializeField] string defeatScene = "Defeat";
    [SerializeField] string victoryScene = "Victory";

    private void Awake()
    {
        PlayerHealth.onPlayerDeath += GoToDefeat;
        BossDamage.onVictory += GoToVictory;
    }

    void GoToDefeat() => SceneManager.LoadSceneAsync(defeatScene);

    void GoToVictory() => SceneManager.LoadSceneAsync(victoryScene);
}
