using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySen : Enemy
{
    public EnemySenBaseState currentState;
    public EnemySenPatrolState patrolState;
    public EnemySenDetectState detectState;
   public EnemySenShellState shellState;
 
    public EnemySenDeathState deathState;
    public EnemySenChargeState chargeState;


    public Transform target;
    public bool isTouch2 = false;

    private void Awake()
    {
        patrolState = new EnemySenPatrolState(this, "isRun");
        detectState = new EnemySenDetectState(this, "isIdle");
        shellState = new EnemySenShellState(this, "isShell");
        deathState = new EnemySenDeathState(this, "isDie");
        chargeState = new EnemySenChargeState(this, "isRun");
   
        target = GameObject.FindGameObjectWithTag("Player").transform;
        currentState = patrolState;
        currentState.OnEnter();
    }
    private void Update()
    {
        currentState.OnExcute();
        if(currentState == shellState)
        {
            return;
        }
    }
  

    public override void Death()
    {

        base.Death();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && isDie == true)
        {
            isTouch2 = true;
        }
    }




    public void SwitchState(EnemySenBaseState enemySenBaseState)
    {
        currentState.OnExit();
        currentState = enemySenBaseState;
        currentState.OnEnter();
        stateTime = Time.time;
    }

}
