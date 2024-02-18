using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossDeadState : BossState
{
    public override void EnterState(BossController boss)
    {
        boss.GetComponent<Collider2D>().enabled = false;
        boss.GetComponent<SpriteRenderer>().enabled = false;
    }

    public override void ExitState(BossController boss)
    {
    }

    public override void UpdateState(BossController boss)
    {
    }
}
