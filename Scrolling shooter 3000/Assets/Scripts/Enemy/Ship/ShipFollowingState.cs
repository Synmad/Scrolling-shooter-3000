using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipFollowingState : ShipState
{
    float speed;
    Vector2 targetPosition;

    GameObject player;

    public override void EnterState(ShipController ship)
    {
        player = GameObject.FindGameObjectWithTag("Player");
        speed = ship.speed;
    }

    public override void ExitState(ShipController ship)
    {
        
    }

    public override void UpdateState(ShipController ship)
    {
        targetPosition = new Vector2(ship.transform.position.x, player.transform.position.y);
        ship.transform.position = Vector2.MoveTowards(ship.transform.position, targetPosition, speed * Time.deltaTime);
        if (Vector2.Distance(ship.transform.position, targetPosition) < 0.1f)
        {
            ship.ChangeState(ship.attacking);
        }
    }
}
