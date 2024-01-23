using UnityEngine;

public class BossArrivingState : BossState
{
    BossController bossController;
    float speed = 2;

    public override void EnterState(BossController boss)
    {
        bossController = boss;
        BossController.onWallReached += Stop;
    }

    public override void ExitState(BossController boss)
    {
        BossController.onWallReached -= Stop;
    }

    public override void UpdateState(BossController boss)
    {
        boss.gameObject.transform.Translate(speed * Time.deltaTime * Vector2.left);
    }

    void Stop() { bossController.ChangeState(bossController.idle); }
}
