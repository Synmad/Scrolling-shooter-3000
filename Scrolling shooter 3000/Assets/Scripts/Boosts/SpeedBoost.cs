using UnityEngine;

public class SpeedBoost : Boost
{
    public override void ApplyEffect(GameObject target)
    {
        target.GetComponent<PlayerMovement>().SpeedUp();
    }
}
