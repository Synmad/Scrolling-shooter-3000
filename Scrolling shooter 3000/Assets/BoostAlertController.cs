using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BoostAlertController : MonoBehaviour
{
    TextMeshProUGUI text;

    private void Awake()
    {
        text = GetComponent<TextMeshProUGUI>();
    }

    private void Update()
    {
        if (PlayerMovement.boosted) 
        {
            text.enabled = true;
        }
        else
        {
            text.enabled = false;
        }
    }
}
