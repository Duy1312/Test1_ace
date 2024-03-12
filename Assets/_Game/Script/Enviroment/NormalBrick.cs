using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalBrick : MonoBehaviour
{
    private Player player;
    [SerializeField] private float forceHitBrick = 5f;
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
        RaycastHit2D hitDown = Physics2D.Raycast(transform.position, Vector2.down);
        if (hitDown.collider != null && hitDown.distance < 0.5f && collision.gameObject.CompareTag("Player") && !hasMovedUp)
        {
            Debug.Log("sd");
            player.GetComponent<Rigidbody2D>().AddForce(Vector2.down * forceHitBrick);
           // StartCoroutine(MoveUpAndReturn());
            rb.AddForce(Vector2.up * forceHitBrick);
            //  transform.position = original;
            StartCoroutine(MoveUpAndReturn());
        }
    }
   
    private IEnumerator MoveUpAndReturn()
    {
        yield return new WaitForSeconds(.2f);

     
        float moveDuration = 0.5f;
        float elapsedTime = 0f;

        while (elapsedTime < moveDuration)
        {
            transform.Translate(Vector2.up * forceHitBrick * Time.deltaTime);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        
        transform.position = original;
        hasMovedUp = true;

    }
}