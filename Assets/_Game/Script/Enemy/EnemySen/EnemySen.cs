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


  [HideInInspector]  public Transform target;
    public bool isTouch2 = false;
    public int countTouch;
    public float coolDown = 3f;
    public float countDown = 0f;

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
        if(countTouch == 1)
        {
            countDown += Time.deltaTime;
        }
        if(countDown > coolDown)
        {
            countDown = 0;
            countTouch = 0;
        }
    
    }
  

    public override void Death()
    {

        base.Death();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player") )
        {
            countTouch++;
        }
        if (countTouch == 2)
        {
            isTouch2 = true;
            countTouch = 0;
            countDown = 0;
        }
         
        if (currentState == shellState && collision.gameObject.CompareTag("Enemy"))
        {
            collision.gameObject.GetComponent<BoxCollider2D>().enabled = false;
            collision.gameObject.GetComponent<Enemy>().isDie = true;


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
