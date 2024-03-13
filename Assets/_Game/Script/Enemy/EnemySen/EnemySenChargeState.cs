using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySenChargeState : EnemySenBaseState
{
    public EnemySenChargeState(EnemySen enemySen, string animName) : base(enemySen, animName)
    {
    }

    public override void OnEnter()
    {
        base.OnEnter();
    }

    public override void OnExcute()
    {
        base.OnExcute();
        if (Time.time >= enemySen.stateTime + enemySen.so.chargeTime)
        {
            if (enemySen.CheckPlayer())
            {
                enemySen.SwitchState(enemySen.detectState);
            }
            else
            {
                enemySen.SwitchState(enemySen.patrolState);
            }
        }
        else
        {
         
            ChargePlayer();
        }
    }

    public override void OnExit()
    {
        base.OnExit();
    }
    void ChargePlayer()
    {
        enemySen.rb.velocity = new Vector2(enemySen.so.chargeSpeed * enemySen.facingDirection, enemySen.rb.velocity.y);
    }


}
