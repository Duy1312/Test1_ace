using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySenPatrolState : EnemySenBaseState
{
    public EnemySenPatrolState(EnemySen enemySen, string animName) : base(enemySen, animName)
    {
    }

    public override void OnEnter()
    {
        base.OnEnter();
    }

    public override void OnExcute()
    {
        base.OnExcute();
        if (enemySen.CheckPlayer())
        {
            enemySen.SwitchState(enemySen.detectState);
        }
       
        if (enemySen.CheckGround()|| enemySen.CheckEnemy())
        {
            enemySen.Rotate();
        }
        if(enemySen.isDie == true)
        {
            enemySen.SwitchState(enemySen.shellState);
        }
        if (enemySen.facingDirection == 1)
        {
            enemySen.rb.velocity = new Vector2(enemySen.so.speed, enemySen.rb.velocity.y);
        }
        else
        {
            enemySen.rb.velocity = new Vector2(-enemySen.so.speed, enemySen.rb.velocity.y);
        }
        if (enemySen.isSendie == true)
        {
            enemySen.SwitchState(enemySen.deathState);
        }

    }

    public override void OnExit()
    {
        base.OnExit();
    }

   
}
