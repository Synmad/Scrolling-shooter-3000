using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverController : MonoBehaviour
{
    private void Awake()
    {
        PlayerDamage.onPlayerDeath += GoToGameOver;
    }

    void GoToGameOver()
    {
        SceneManager.LoadScene("Gameplay");
    }
}
