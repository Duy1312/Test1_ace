using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class BrickInteraction : MonoBehaviour
{

    private Rigidbody2D rb;
    private Vector2 originalPosition;

    public float jumpForce = 5f;
    public Transform playerHead;

    private void Start()
    {
      
        rb = GetComponent<Rigidbody2D>();
        originalPosition = transform.position;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && collision.contacts[0].point.y > playerHead.position.y)
        {
       
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }
    }

    private void Update()
    {
        if (transform.position.y <= originalPosition.y + 0.1f)
        {
            rb.velocity = Vector2.zero;
            transform.position = originalPosition;
         
        }
    }
}