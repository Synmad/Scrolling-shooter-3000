using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipAdjustingState : ShipState
{
    float speed;
    ShipController _ship;
    public override void EnterState(ShipController ship)
    {
        speed = ship.speed;
        _ship = ship;
    }

    public override void ExitState(ShipController ship)
    {
        
    }

    public override void UpdateState(ShipController ship)
    {
        
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            _ship.ChangeState(_ship.following);
        }
    }
}
