using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyNamDeathState : EnemyNamBaseState
{
    public EnemyNamDeathState(EnemyNam enemyNam, string animName) : base(enemyNam, animName)
    {
    }

    public override void OnEnter()
    {
        base.OnEnter();
        enemyNam.rb.velocity = Vector3.zero;

        enemyNam.StartCoroutine(enemyNam.OnDespawn());
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
