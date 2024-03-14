using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    [Header("Run")]
    [SerializeField] private float speed = 5f;

    [Header("Jump")]
    [SerializeField] private float jumpForce = 10f;
    public bool isJumping = false;
    [Header("CheckSurrounding")]
    [SerializeField] private Transform ledgeDetectDown;
    [SerializeField] private float checkGroundDistance;
    [SerializeField] private LayerMask whatisGround;
    [SerializeField] private float checkEnemyDistance = 5f;
    [Header("Anim")]
    [SerializeField] private Animator animator;
    [Header("Weapon")]
    [SerializeField] private BulletPlayer bombPrefab;
    private float horizontalInput;
  
    [Header("Enemy")]
    [SerializeField] private float forceHitEnemy;
    [SerializeField] private LayerMask whatisEnemy;
    [Header("Brick")]
    [SerializeField] private float forceHitBrick;
    private bool canMove = true;
    [SerializeField] private int scoreIncrese;
    [Header("Attack")]
    [SerializeField] private float coolDown = 2f;
    [SerializeField] private float timeWaitToBullet = 0f;
    [SerializeField] private float lauchForce = 5f;
    [SerializeField] private Transform pointShoot;
    private bool isAttack;
    private PlayerHealth playerhealth;
    private bool checkGround;
    public bool isFacingRight = false;
    void Start()
    {
        isAttack = false;
        playerhealth = GetComponent<PlayerHealth>();
    }
   

    void Update()
    {
        //  horizontalInput = Input.GetAxisRaw("Horizontal");
        // float verticalInput = Input.GetAxisRaw("Vertical");
        if (canMove)
        {
            checkGround = CheckGrounded();
            if (checkGround)
            {
                CheckJump();
            }

            if (!checkGround && rb.velocity.y < 0)
            {
                isJumping = false;

            }


            ApplyMove();


            timeWaitToBullet += Time.deltaTime;

            if (checkGround && Input.GetKeyDown(KeyCode.Z) )
            {
                ThrowBomb();
                 
            }
           


            UpdateAnim();
        }
        

    }

 
    private void ApplyMove()
    {
        if (horizontalInput > 0f && isFacingRight == true)
        {
            Flip();

        }else if(horizontalInput < 0f && isFacingRight == false)
        {
            Flip();
        }
        rb.velocity = new Vector2(horizontalInput * speed, rb.velocity.y);
    }
  
    private bool CheckGrounded()
    {
        Debug.DrawLine(transform.position,transform.position + Vector3.down * checkGroundDistance,Color.red);
        RaycastHit2D hit = Physics2D.Raycast(transform.position,Vector2.down, checkGroundDistance, whatisGround);
        return hit.collider != null;
       
    }
    private void CheckJump()
    {
        if(Input.GetKeyDown(KeyCode.Space) && checkGround && playerhealth.hasDied == false)
        {
            isJumping = true;
           rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            checkGround = false;

        }
        if (Input.GetKeyUp(KeyCode.Space)&& playerhealth.hasDied == false)
        {
            isJumping = true;
            rb.velocity = new Vector2(rb.velocity.x,rb.velocity.y *jumpForce*0.5f);
            checkGround = false;

        }
    }
    public void PressJump()
    {
        if (CheckGrounded()&& playerhealth.hasDied == false)
        {
            isJumping = true;
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);

        }


    }
    private void UpdateAnim()
    {
        animator.SetBool(Constant.AnimIdle, rb.velocity.x == 0);
        animator.SetFloat(Constant.AnimRun, Mathf.Abs(horizontalInput));
        animator.SetBool(Constant.AnimJump, isJumping);

    }
   public void EnableController()
    {
        canMove = true;
    }

    public void DisableController()
    {
        canMove = false;
    }
    public void ThrowBomb()
    {
    if(timeWaitToBullet > coolDown)
        {
            Bullet newArrow = Instantiate(bombPrefab, pointShoot.transform.position, Quaternion.identity);
            newArrow.GetComponent<Rigidbody2D>().velocity = transform.right * lauchForce;
            timeWaitToBullet = 0;
        }

            
        

    }
    private void ResetAttack()
    { 
        isAttack = false;

    }
    private void OnDeath()
    {
        Destroy(gameObject);
    }
    private void Flip()
    {
        isFacingRight = !isFacingRight;
        transform.Rotate(0,180,0);
    }
  
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(ledgeDetectDown.transform.position, checkEnemyDistance, whatisEnemy);
        foreach (Collider2D collider in colliders)
        {
            if(collider != null)
            {
                Debug.Log("Có va chạm với " + collider.gameObject.name);
                rb.velocity = new Vector2(rb.velocity.x, forceHitEnemy);


                collision.gameObject.GetComponent<Enemy>().Death();
                
                PlayerScore.Instance.CountScore(20);
            }
        }
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.up, 1f, whatisGround);
        if(hit.collider != null && collision.gameObject.CompareTag("Brick"))
        {
           rb.AddForce(Vector2.down * forceHitBrick);
            StartCoroutine( collision.gameObject.GetComponent<NormalBrick>().MoveUpAndReturn());
        }
        //RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down,checkEnemyDistance, whatisEnemy);
        //if ( hit.collider != null && collision.gameObject.CompareTag("Enemy"))
        //{
        //    Debug.Log("Có va chạm với " + hit.collider.gameObject.name);
        //    rb.AddForce(Vector2.up *forceHitEnemy);
        //    collision.gameObject.GetComponent<BoxCollider2D>().enabled = false;

        //    collision.gameObject.GetComponent<Enemy>().Death();
        //    //   collision.gameObject.GetComponent<Enemy>().enabled = false;
        //    collision.gameObject.GetComponent<Rigidbody2D>().freezeRotation = false;
        //    collision.gameObject.GetComponent<Rigidbody2D>().gravityScale = 20f;
        //    PlayerScore.Instance.CountScore(20);
        //}
    }

    public void SetMove(float horizontal)
    {
        this.horizontalInput = horizontal;
    }
    public virtual void OnDrawGizmos()
    {
        Gizmos.DrawLine(transform.position, transform.position + (Vector3)(Vector2.down  * checkEnemyDistance));
        Gizmos.DrawWireSphere(ledgeDetectDown.position,checkEnemyDistance );
        Gizmos.DrawLine(transform.position, transform.position + (Vector3)(Vector2.up * 1f));

    }
}
