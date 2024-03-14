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

    private void Update()
    {
        if(hasDied)
        {
            return;
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy") && hasDied == false)
        {
            UIManager.Instance.GameOver();
 
            hasDied = true;
     
            animator.SetBool(Constant.AnimDie, hasDied);
        }
    }

}
