using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossHealthBar : MonoBehaviour
{
    [SerializeField] Slider slider;

    public void SetUpBar(int maxHealth)
    {
        slider.maxValue = maxHealth;
        slider.value = slider.maxValue;
    }

    public void UpdateBar(int newHealth)
    {
        Debug.Log("updated");
        slider.value = newHealth;
    }
}
