using UnityEngine;

public class DamageBoost : Boost
{
    public override string boostName => "Damage";

    public override void Effect() => Debug.Log("Damage!!");
}
