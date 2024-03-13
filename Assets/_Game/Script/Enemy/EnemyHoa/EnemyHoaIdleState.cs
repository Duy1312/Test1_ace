using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHoaIdleState : EnemyHoaBaseState
{
    public EnemyHoaIdleState(EnemyHoa enemyHoa, string animName) : base(enemyHoa, animName)
    {
    }

    public override void OnEnter()
    {
        base.OnEnter();
        enemyHoa.rb.velocity = Vector3.zero;
    }

    public override void OnExcute()
    {
        base.OnExcute();
        if (enemyHoa.CheckPlayer())
        {
            enemyHoa.SwitchState(enemyHoa.attackState);
        }
    }

    public override void OnExit()
    {
        base.OnExit();
    }

}
