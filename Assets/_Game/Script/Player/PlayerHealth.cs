using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private float waitToDied = 2f;
    public bool hasDied;

    public bool Death;
    private Animator animator;
    private Rigidbody2D rb;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        hasDied = false;
        Death = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.y < -20)
        {
            Death = true;
        }
        if(Death == true)
        {
            Die();
            UIManager.Instance.GameOver();
        }
     
    }

    private IEnumerator Die()
    {
        yield return new WaitForSeconds(waitToDied);
        Destroy(gameObject);

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy") && hasDied == false)
        {
            hasDied = true;
            rb.gravityScale = 20f;
            gameObject.GetComponent<CapsuleCollider2D>().enabled = false;
            animator.SetBool(Constant.AnimDie, hasDied);
        }
    }

}
