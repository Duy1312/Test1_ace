using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyNamPatrolState : EnemyNamBaseState
{
    public EnemyNamPatrolState(EnemyNam enemyNam, string animName) : base(enemyNam, animName)
    {
    }

    public override void OnEnter()
    {
        base.OnEnter();
    }

    public override void OnExcute()
    {
        base.OnExcute();
        if (enemyNam.CheckPlayer())
        {
            enemyNam.SwitchState(enemyNam.chargeState);
        }

        if (enemyNam.CheckGround())
        {
            enemyNam.Rotate();
        }
        if (enemyNam.CheckEnemy())
        {
            enemyNam.Rotate();
        }

        if (enemyNam.facingDirection == 1)
        {
            enemyNam.rb.velocity = new Vector2(enemyNam.so.speed, enemyNam.rb.velocity.y);
        }
        else
        {
            enemyNam.rb.velocity = new Vector2(-enemyNam.so.speed, enemyNam.rb.velocity.y);
        }

    }


    public override void OnExit()
    {
        base.OnExit();
    }

 
}
