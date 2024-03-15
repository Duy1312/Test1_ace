using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private float waitToDied = 2f;
    public bool hasDied;

 
    private Animator animator;
    private Rigidbody2D rb;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        hasDied = false;
   
    }


    private void Update()
    {
        if(hasDied)
        {
            UIManager.Instance.GameOver();
            animator.SetBool(Constant.AnimDie, hasDied);
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
