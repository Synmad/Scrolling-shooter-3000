using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBoost : Boost
{
    public override void ApplyEffect(GameObject target)
    {
        target.GetComponent<PlayerHealth>().Heal(1);
    }
    //if player full health, apply shield instead
}
