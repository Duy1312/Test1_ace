using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyNamChaseState : EnemyNamBaseState
{
    public EnemyNamChaseState(EnemyNam enemyNam, string animName) : base(enemyNam, animName)
    {
    }


    public override void OnEnter()
    {
        base.OnEnter();
    }

    public override void OnExcute()
    {
        base.OnExcute();
        if (Time.time >= enemyNam.stateTime + enemyNam.so.chargeTime)
        {
            if (enemyNam.CheckPlayer())
            {
                enemyNam.SwitchState(enemyNam.chargeState);
            }
            else
            {
                enemyNam.SwitchState(enemyNam.patrolState);
            }
        }
        else
        {

            ChargePlayer();
        }
        if (enemyNam.isDie == true)
        {
            enemyNam.SwitchState(enemyNam.deathState);
        }
    }

    public override void OnExit()
    {
        base.OnExit();
    }
    void ChargePlayer()
    {
        enemyNam.rb.velocity = new Vector2(enemyNam.so.chargeSpeed * enemyNam.facingDirection, enemyNam.rb.velocity.y);
    }

}
