using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScrollingBackground : MonoBehaviour
{
    [SerializeField] RawImage background;
    [SerializeField] float xMovement, yMovement;

    private void Update()
    {
        background.uvRect = new Rect(background.uvRect.position + new Vector2(xMovement, yMovement) * Time.deltaTime, background.uvRect.size);
    }
}
