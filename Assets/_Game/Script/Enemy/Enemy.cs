
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Enemy : MonoBehaviour
{
   

    public Animator anim;
    public Rigidbody2D rb;
    public Transform ledgeDetect;
    public Transform ledgeBehindCheck;

    public LayerMask whatisGround;
    public LayerMask whatisPlayer;

    public LayerMask whatisEnemy;


    public float stateTime;
    public int facingDirection = 1;

    
    public bool isDie = false;
    public EnemySO so;
 

 
   
    public virtual void Death()
    {
        isDie = true;
        StartCoroutine(OnDespawn());
    }
    
    public IEnumerator OnDespawn()
    {
        yield return new WaitForSeconds(1);
        Destroy(gameObject);
    }




    public virtual void Rotate()
    {
        facingDirection = -facingDirection;
        transform.Rotate(0f, 180f, 0f);
    }
  
 
    public virtual bool CheckPlayer()
    {
        RaycastHit2D hit = Physics2D.Raycast(ledgeDetect.position, facingDirection == 1 ? Vector2.right : Vector2.left, so.checkDistancePlayer, whatisPlayer);
        if (hit.collider != null)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    public virtual bool CheckEnemy()
    {
        RaycastHit2D hit = Physics2D.Raycast(ledgeDetect.position, facingDirection == 1 ? Vector2.right : Vector2.left, so.checkDistancePlayer, whatisEnemy);
        if (hit.collider != null)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    public virtual bool CheckGround()
    {
        RaycastHit2D hit = Physics2D.Raycast(ledgeDetect.position, Vector2.down, so.checkDistanceGround, whatisGround);

        if (hit.collider == null)
        {

            return true;
        }
        else
        {
            return false;
        }
    }


    public virtual void OnDrawGizmos()
    {
        Gizmos.DrawLine(ledgeDetect.position, ledgeDetect.position + (Vector3)(Vector2.right * facingDirection * so.checkDistancePlayer));
        Gizmos.DrawLine(ledgeDetect.position, ledgeDetect.position + (Vector3)(Vector2.down * so.checkDistanceGround));

    }

   
}
