using UnityEngine;

public class SpeedBoost : Boost
{
    public override string boostName => "Speed";

    public override void Effect() => Debug.Log("Speed!!");
}
