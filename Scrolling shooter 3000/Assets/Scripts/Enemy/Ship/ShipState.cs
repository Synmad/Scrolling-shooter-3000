using UnityEngine;

public abstract class ShipState : MonoBehaviour
{
    public abstract void EnterState(ShipController ship);
    public abstract void UpdateState(ShipController ship);
    public abstract void ExitState(ShipController ship);
}
