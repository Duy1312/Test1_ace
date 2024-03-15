using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyNam : Enemy
{
    public EnemyNamBaseState currentState;
    public EnemyNamPatrolState patrolState;


    public EnemyNamDeathState deathState;
    public EnemyNamChaseState chargeState;


    [HideInInspector] public Transform target;


    private void Awake()
    {
        patrolState = new EnemyNamPatrolState(this, "isRun");
        
        deathState = new EnemyNamDeathState(this, "isDie");
        chargeState = new EnemyNamChaseState(this, "isRun");

        target = GameObject.FindGameObjectWithTag("Player").transform;
        currentState = patrolState;
        currentState.OnEnter();
    }
    private void Update()
    {
        currentState.OnExcute();
        if(isDie == true)
        {
            currentState = deathState;
        }
    }


    public override void Death()
    {

        base.Death();
    }
    



    public void SwitchState(EnemyNamBaseState enemyNamBaseState)
    {
        currentState.OnExit();
        currentState = enemyNamBaseState;
        currentState.OnEnter();
        stateTime = Time.time;
    }
}
