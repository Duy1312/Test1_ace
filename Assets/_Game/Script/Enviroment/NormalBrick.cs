using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalBrick : MonoBehaviour
{
    public Transform ledgeDetect;
    private Player player;
    [SerializeField] private float forceHitBrick = 5f;
    [SerializeField] private LayerMask whatisPlayer;
    Vector2 original;
    private Rigidbody2D rb;
    private bool hasMovedUp = false;
    private void Start()
    {
         original = gameObject.transform.position;
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        rb = gameObject.GetComponent<Rigidbody2D>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
     //   RaycastHit2D hit = Physics2D.Raycast(ledgeDetect.transform.position, Vector2.down, 1f, whatisPlayer);

      //  RaycastHit2D hitDown = Physics2D.Raycast(transform.position  , Vector2.down * 1.1f);
      //  if (hit.collider != null && collision.gameObject.CompareTag("Player") && !hasMovedUp)
    //    {
        
        //    player.GetComponent<Rigidbody2D>().AddForce(Vector2.down * forceHitBrick);
           // StartCoroutine(MoveUpAndReturn());
          
            //  transform.position = original;
         //   StartCoroutine(MoveUpAndReturn());
     //   }
    }
   
    public IEnumerator MoveUpAndReturn()
    {
        yield return new WaitForSeconds(.05f);

     
        float moveDuration = 0.8f;
        float elapsedTime = 0f;

        while (elapsedTime < moveDuration)
        {
            transform.Translate(Vector2.up * forceHitBrick/20 * Time.deltaTime);
            elapsedTime += Time.deltaTime * 5f;
            yield return null;
        }

        
        transform.position = original;
        hasMovedUp = false;

    }
}