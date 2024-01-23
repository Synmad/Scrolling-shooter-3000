using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public abstract class BossState
{
    public abstract void EnterState(BossController boss);
    public abstract void UpdateState(BossController boss);
    public abstract void ExitState(BossController boss);
    
}