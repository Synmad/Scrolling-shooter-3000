using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipController : Enemy
{
    #region State Machine Variables
    ShipState currentState;

    public ShipFollowingState following;
    public ShipAttackingState attacking;
    public ShipIdleState idle;
    #endregion

    public float speed;

    public float attackCooldown;

    public GameObject bulletSpawner;

    private void Awake()
    {
        following = gameObject.AddComponent<ShipFollowingState>(); idle = gameObject.AddComponent<ShipIdleState>(); attacking = gameObject.AddComponent<ShipAttackingState>();
    }

    private void Start() => ChangeState(following);

    private void Update() => currentState.UpdateState(this);

    public void ChangeState(ShipState newState)
    {
        currentState?.ExitState(this);
        currentState = newState;
        currentState.EnterState(this);
    }
}
