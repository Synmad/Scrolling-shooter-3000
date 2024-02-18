using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipFollowingState : ShipState
{
    float speed;
    Vector2 targetPosition;

    GameObject player;

    public bool playerFound;
    bool followingShip;
    [SerializeField] ShipFollowingState shipToFollow;

    ShipController _ship;

    public override void EnterState(ShipController ship)
    {
        Debug.Log(ship.gameObject.name + "enters following");
        _ship = ship;
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
        if(followingShip && shipToFollow.playerFound)
        {
            playerFound = false;
            ship.ChangeState(ship.attacking);
        }
        if (Vector2.Distance(ship.transform.position, targetPosition) < 0.1f)
        {
            playerFound = true;
            ship.ChangeState(ship.attacking);
        }
        else playerFound = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Enemy") && playerFound == false)
        {
            followingShip = true;
            shipToFollow = collision.GetComponent<ShipFollowingState>(); 
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        followingShip = false;
    }
}
