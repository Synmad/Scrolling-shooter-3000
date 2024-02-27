using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossColorChange : MonoBehaviour
{
    [SerializeField] UnityEngine.Color targetColor;
    [SerializeField] BossController boss;

    float timeElapsed;
    float maxTime;

    SpriteRenderer sprite;
    float lerpTime;
    UnityEngine.Color originalColor;

    private void Awake()
    {
        sprite = GetComponent<SpriteRenderer>();
        originalColor = sprite.color;
    }

    private void Update()
    {
        timeElapsed += Time.deltaTime;
        if(timeElapsed >= maxTime)
        {
            timeElapsed = 0;
        }
    }

    public void ChangeColor(float duration)
    {
        maxTime = duration;
        sprite.color = Color.Lerp(originalColor, targetColor, timeElapsed);
    }
    public void RestoreColor()
    {
        sprite.color = originalColor;
    }
}
