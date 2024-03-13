using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHoaAttackState : EnemyHoaBaseState
{
    float attackCoolDown = 1f;
    public EnemyHoaAttackState(EnemyHoa enemyHoa, string animName) : base(enemyHoa, animName)
    {
    }

    public override void AnimationAttackTrigger()
    {

        base.AnimationAttackTrigger();
        enemyHoa.Shoot();

    }

    public override void AnimationFinisedTrigger()
    {
        base.AnimationFinisedTrigger();
        enemyHoa.SwitchState(enemyHoa.idleState);
    }

    public override void OnEnter()
    {
        base.OnEnter();
        attackCoolDown = 1f;
    }

    public override void OnExcute()
    {
        base.OnExcute();

        if (Time.time >= enemyHoa.stateTime + attackCoolDown)
        {
            enemyHoa.SwitchState(enemyHoa.idleState);
        }
    }

    public override void OnExit()
    {
        base.OnExit();
    }


}
