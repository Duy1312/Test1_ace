using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHoaBaseState 
{
    protected EnemyHoa enemyHoa;
    protected string animName;
    public EnemyHoaBaseState(EnemyHoa enemyHoa, string animName)
    {
        this.enemyHoa = enemyHoa;
        this.animName = animName;
    }
    public virtual void OnEnter()
    {
        enemyHoa.anim.SetBool(animName, true);
    }
    public virtual void OnExcute()
    {

    }
    public virtual void OnExit()
    {
        enemyHoa.anim.SetBool(animName, false);
    }
    public virtual void AnimationFinisedTrigger()
    {

    }
    public virtual void AnimationAttackTrigger()
    {

    }
}
