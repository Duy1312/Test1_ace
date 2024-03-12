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
    [SerializeField] private float checkGroundDistance;
    [SerializeField] private LayerMask whatisGround;
    [SerializeField] private float checkEnemyDistance = 5f;
    [Header("Anim")]
    [SerializeField] private Animator animator;
    [Header("Weapon")]
    [SerializeField] private Bullet bombPrefab;
    private float horizontalInput;
    [Header("SavePoint")]
     private Vector3 savePoint;
    [Header("Enemy")]
    [SerializeField] private float forceHitEnemy;
    [Header("Brick")]
    [SerializeField] private float forceHitBrick;

    [SerializeField] private int scoreIncrese;
    [Header("Attack")]
 private bool isAttack;

    private bool checkGround;
    private bool isFacingRight = false;
    void Start()
    {
        isAttack = false;
        transform.position = savePoint;
        SavePoint();
    }
   

    void Update()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        // float verticalInput = Input.GetAxisRaw("Vertical");
         checkGround = CheckGrounded();
        if(checkGround)
       {
            CheckJump();
        }
    
        if(!checkGround && rb.velocity.y < 0)
        {
            isJumping = false;

      }
       
        
        ApplyMove();



       
        if (checkGround && Input.GetKeyDown(KeyCode.Z))
        {
            ThrowBomb();
        }
      
      
        UpdateAnim();

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
        if(Input.GetKeyDown(KeyCode.Space))
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
    public void SavePoint()
    {
        savePoint = transform.position;
    }
   private void ThrowBomb()
    {
        Instantiate(bombPrefab,transform.position, Quaternion.identity);
 
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
   


            RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down);
        if( hit.collider != null&&hit.distance < 0.9f && collision.gameObject.CompareTag("Enemy"))
        {
           rb.AddForce(Vector2.up *forceHitEnemy);
            collision.gameObject.GetComponent<BoxCollider2D>().enabled = false;
            collision.gameObject.GetComponent<Enemy>().enabled = false;
            collision.gameObject.GetComponent<Rigidbody2D>().freezeRotation = false;
            collision.gameObject.GetComponent<Rigidbody2D>().gravityScale = 20f;
        }
    }
    
}
