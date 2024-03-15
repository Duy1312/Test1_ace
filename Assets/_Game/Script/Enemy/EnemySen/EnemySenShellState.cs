using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySenShellState : EnemySenBaseState
{
    float blockTime;
    public EnemySenShellState(EnemySen enemySen, string animName) : base(enemySen, animName)
    {
    }


    public override void OnEnter()
    {
        base.OnEnter();
        blockTime = 3f;
       
    }

    public override void OnExcute()
    {
        base.OnExcute();
        if (Time.time >= enemySen.stateTime + blockTime)
        {
            enemySen.SwitchState(enemySen.patrolState);
            enemySen.isDie = false;
        }
        else
        {
           if(enemySen.CheckGroundAhead())
            {
                enemySen.Rotate();
            }
            else
            {
                enemySen.rb.velocity = new Vector2(enemySen.rb.velocity.x,  -10);
            }
           
        }
        if(enemySen.isTouch2 == true)
        {

            if (enemySen.facingDirection == 1)
            {
                enemySen.rb.velocity = new Vector2(enemySen.so.speed * 30, enemySen.rb.velocity.y);
            }
            else
            {
                enemySen.rb.velocity = new Vector2(-enemySen.so.speed * 30, enemySen.rb.velocity.y);
            }
        }
        else
        {
            enemySen.rb.velocity = Vector2.zero;
        }
        if (enemySen.isSendie == true)
        {
            enemySen.SwitchState(enemySen.deathState);
        }


    }
    public override void OnExit()
    {
        base.OnExit(); 
        enemySen.isTouch2 = false;
    }


}
