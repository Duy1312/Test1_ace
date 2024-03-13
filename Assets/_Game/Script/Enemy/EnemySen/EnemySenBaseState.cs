using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySenBaseState
{
    protected EnemySen enemySen;
    protected string animName;
    public EnemySenBaseState(EnemySen enemySen, string animName)
    {
        this.enemySen = enemySen;
        this.animName = animName;
    }
    public virtual void OnEnter()
    {
        enemySen.anim.SetBool(animName, true);
    }
    public virtual void OnExcute()
    {

    }
    public virtual void OnExit()
    {
        enemySen.anim.SetBool(animName, false);
    }
}
