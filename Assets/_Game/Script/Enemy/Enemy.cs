using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float speed = 5f;
    [SerializeField] private Transform ledgeDetect;

    [SerializeField] private float ledgeDetectDistance =1f;

    [SerializeField] private LayerMask whatisground;
    private float facingDir = 1;
    private GameObject player;
    private Animator animator;
    private Rigidbody2D rb;
    private bool isdeath = false;
   private IState currentstate;
    private bool isFacingRight = true;
    private Player target;
    private PatrolStateOcSen patrolstate = new PatrolStateOcSen();
    private IdleStateOcSen idleState = new IdleStateOcSen();
    private ChaseStateOcSen chasestate = new ChaseStateOcSen();

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.FindWithTag("Player");
        animator = GetComponent<Animator>();
       ChangeState(patrolstate);
    }
    private void Update()
    {
        currentstate.OnExcute(this);
        UpdateAnim();
     
    }
    private void FixedUpdate()
    {
        CheckSurround();
    }
    private bool CheckSurround()
    {

        RaycastHit2D hit = Physics2D.Raycast(ledgeDetect.position, Vector2.down,ledgeDetectDistance,whatisground);
        return hit.collider != null;

    }
    public void ApplyMove()
    {
        rb.velocity = transform.right * speed;
    }
    public void ApplyDoubleMove()
    {
        rb.velocity = transform.right * speed;
    }
    private void UpdateAnim()
    {
        animator.SetBool(Constant.AnimRun, Mathf.Abs(rb.velocity.x)>0);
    }
    public void StopMoving()
    {
        rb.velocity = Vector2.zero;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player")&& transform.position.y<-7) {
            StartCoroutine(OnDespawn());
        }
    }


    IEnumerator OnDespawn()
    {
        Destroy(gameObject);
        yield return new WaitForSeconds(2);
    }
    private void OnDeath()
    {
        animator.SetBool(Constant.AnimDie, isdeath);
    }
    
    public void ChangeState(IState state)
    {
        if(currentstate != state)
        {
            currentstate.OnExit(this);
            currentstate = state;
            currentstate.OnEnter(this);
        }
    }
    public bool IsTargetInRange(Player target)
    {
        if(Vector2.Distance(target.transform.position, transform.position) < 0.5f)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    public void SetTargetInRange(Player player)
    {
        if(player != null)
        {
            if (IsTargetInRange(player))
            {
                ChangeState(patrolstate);
            }
            else
            {
                ChangeState(idleState);
            }
        }
    }
    public void ChangeDirection(bool isFacingRight)
    {
        this.isFacingRight = isFacingRight;
     transform.rotation = isFacingRight ? Quaternion.Euler(0,0,0) : Quaternion.Euler(0,180,0);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("EnemySign"))
        {
            ChangeDirection(!isFacingRight);
        }
    }
}
