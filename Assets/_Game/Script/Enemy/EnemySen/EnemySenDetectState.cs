using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySenDetectState : EnemySenBaseState
{
    public EnemySenDetectState(EnemySen enemySen, string animName) : base(enemySen, animName)
    {
    }

    public override void OnEnter()
    {
        base.OnEnter();
        enemySen.rb.velocity = Vector2.zero;
    }

    public override void OnExcute()
    {
        base.OnExcute();
        if (!enemySen.CheckPlayer())
        {
            enemySen.SwitchState(enemySen.patrolState);
        }
        else
        {
            if (Time.time >= enemySen.stateTime + enemySen.so.detectWaitTime)
            {
                enemySen.SwitchState(enemySen.chargeState);
            }
        }
    }

    public override void OnExit()
    {
        base.OnExit();
    }

    
}
