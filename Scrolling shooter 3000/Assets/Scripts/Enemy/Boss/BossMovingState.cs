using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossMovingState : BossState
{
    GameObject top; GameObject mid; GameObject bot;

    Vector2 targetPosition;

    float speed = 5;

    public override void EnterState(BossController boss)
    {
        Debug.Log("enter moving");

        top = boss.top; mid = boss.mid; bot = boss.bot;
    }
    public override void UpdateState(BossController boss)
    {
        if(PlayerSection.section == PlayerSection.atSection.top) { targetPosition = new Vector2(boss.transform.position.x, top.transform.position.y); }

        if (PlayerSection.section == PlayerSection.atSection.mid) { targetPosition = new Vector2(boss.transform.position.x, mid.transform.position.y); }

        if (PlayerSection.section == PlayerSection.atSection.bot) { targetPosition = new Vector2(boss.transform.position.x, bot.transform.position.y); }

        boss.transform.position = Vector2.MoveTowards(boss.transform.position, targetPosition, speed * Time.deltaTime);

        if (Vector2.Distance(boss.transform.position, targetPosition) < 0.1f) { boss.ChangeState(boss.attacking); }

    }
    public override void ExitState(BossController boss)
    {
        Debug.Log("exit moving");
    }
    
}
