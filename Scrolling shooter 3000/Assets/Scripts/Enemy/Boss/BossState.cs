public abstract class BossState
{
    public abstract void EnterState(BossController boss);
    public abstract void UpdateState(BossController boss);
    public abstract void ExitState(BossController boss);
    
}