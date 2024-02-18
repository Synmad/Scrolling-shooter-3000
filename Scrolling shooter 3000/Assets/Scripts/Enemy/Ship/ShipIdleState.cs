using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipIdleState : ShipState
{
    float timerDuration;
    float timeLeft;
    public override void EnterState(ShipController ship)
    {
        timerDuration = ship.attackCooldown;
        timeLeft = timerDuration;
    }

    public override void ExitState(ShipController ship)
    {
    }

    public override void UpdateState(ShipController ship)
    {
        timeLeft -= Time.deltaTime;
        if(timeLeft <= 0)
        {
            ship.ChangeState(ship.following);
        }
    }
}
