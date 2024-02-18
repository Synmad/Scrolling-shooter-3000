using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthDisplayController : MonoBehaviour
{
    int numOfHearts;

    [SerializeField] Image[] hearts;
    [SerializeField] Sprite fullHeart;
    [SerializeField] Sprite emptyHeart;

    [SerializeField] PlayerHealth player;

    private void Awake()
    {
        //PlayerCollision.onPlayerHit += UpdateHealth;
    }

    private void Update()
    {
        for (int i = 0; i < hearts.Length; i++)
        {
            if (i < player.curHealth)
            {
                hearts[i].sprite = fullHeart;
            }
            else
            {
                hearts[i].sprite = emptyHeart;
            }
        }
    }

    void UpdateHealth()
    {
        
    }
}
