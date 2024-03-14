using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHoaDeathState : EnemyHoaBaseState
{
    public EnemyHoaDeathState(EnemyHoa enemyHoa, string animName) : base(enemyHoa, animName)
    {
    }

    public override void OnEnter()
    {
        base.OnEnter();
        enemyHoa.rb.velocity = Vector3.zero;

        enemyHoa.StartCoroutine(enemyHoa.OnDespawn());
    }

    public override void OnExcute()
    {
        base.OnExcute();
    }

    public override void OnExit()
    {
        base.OnExit();
    }

  
}
