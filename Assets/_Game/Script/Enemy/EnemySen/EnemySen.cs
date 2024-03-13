using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySen : Enemy
{
    public EnemySenBaseState currentState;
    public EnemySenPatrolState patrolState;
    public EnemySenDetectState detectState;
   
 
    public EnemySenDeathState deathState;
    public EnemySenChargeState chargeState;


    public Transform target;


    private void Awake()
    {
        patrolState = new EnemySenPatrolState(this, "isRun");
        detectState = new EnemySenDetectState(this, "isIdle");
   
        deathState = new EnemySenDeathState(this, "isDie");
        chargeState = new EnemySenChargeState(this, "isRun");
   
        target = GameObject.FindGameObjectWithTag("Player").transform;
        currentState = patrolState;
        currentState.OnEnter();
    }
    private void Update()
    {
        currentState.OnExcute();
    }
  

    public override void Death()
    {

        base.Death();
    }


  


   
    public void SwitchState(EnemySenBaseState enemySenBaseState)
    {
        currentState.OnExit();
        currentState = enemySenBaseState;
        currentState.OnEnter();
        stateTime = Time.time;
    }

}
