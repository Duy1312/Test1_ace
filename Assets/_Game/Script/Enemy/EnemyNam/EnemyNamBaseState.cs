using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyNamBaseState 
{
    protected EnemyNam enemyNam;
    protected string animName;
    public EnemyNamBaseState(EnemyNam enemyNam, string animName)
    {
        this.enemyNam = enemyNam;
        this.animName = animName;
    }
    public virtual void OnEnter()
    {
        enemyNam.anim.SetBool(animName, true);
    }
    public virtual void OnExcute()
    {

    }
    public virtual void OnExit()
    {
        enemyNam.anim.SetBool(animName, false);
    }
}
