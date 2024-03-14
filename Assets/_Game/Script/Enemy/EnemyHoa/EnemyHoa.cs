using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHoa : Enemy
{
    public EnemyHoaBaseState currentState;
    public EnemyHoaIdleState idleState;
    public EnemyHoaAttackState attackState;


    public EnemyHoaDeathState deathState;
  
    public GameObject bullet;
    public float shootSpeed;

    public Transform target;


    private void Awake()
    {
        currentState = new EnemyHoaBaseState(this, "isIdle");
        idleState = new EnemyHoaIdleState(this, "isIdle");

        deathState = new EnemyHoaDeathState(this, "isDie");
        attackState = new EnemyHoaAttackState(this, "isAttack");

        target = GameObject.FindGameObjectWithTag("Player").transform;
        currentState = idleState;
        currentState.OnEnter();
    }
    private void Update()
    {
        currentState.OnExcute();
        if (isDie == true)
        {
            currentState = deathState;
        }
    }


    public override void Death()
    {

        base.Death();
    }



    public virtual void AnimationFinisedTrigger()
    {
        currentState.AnimationFinisedTrigger();
    }
    public virtual void AnimationAttackTrigger()
    {
        currentState.AnimationAttackTrigger();
    }


    public void SwitchState(EnemyHoaBaseState enemyHoaBaseState)
    {
        currentState.OnExit();
        currentState = enemyHoaBaseState;
        currentState.OnEnter();
        stateTime = Time.time;
    }
    public void Shoot()
    {
        anim.SetBool("isAttack", true);
        GameObject newBullet = Instantiate(bullet, transform.position, Quaternion.identity);

        Rigidbody2D rbBullet = newBullet.GetComponent<Rigidbody2D>();
     
        rbBullet.velocity = new Vector2(shootSpeed , 0f);
    }
}
