using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossController : Enemy
{
    public static BossState currentState;

    public BossArrivingState arriving = new BossArrivingState();
    public BossIdleState idle = new BossIdleState();
    public BossMovingState moving = new BossMovingState();
    public BossAttackingState attacking = new BossAttackingState();
    public BossDeadState dead = new BossDeadState();

    public GameObject top; public GameObject mid; public GameObject bot;

    public static Action onWallReached;

    public GameObject laser { get; private set; }
    public bool chargingLaser;

    private void OnEnable()
    {
        arriving = new BossArrivingState();
        idle = new BossIdleState();
        moving = new BossMovingState();
        attacking = new BossAttackingState();
        dead = new BossDeadState();
        ChangeState(arriving);
        laser = transform.Find("Laser").gameObject;
    }

    private void Update()
    {
        currentState.UpdateState(this);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("BossWall")) { onWallReached?.Invoke(); }
    }

    public void ChangeState(BossState newState)
    {
        currentState?.ExitState(this);
        currentState = newState;
        currentState.EnterState(this);
    }
}
