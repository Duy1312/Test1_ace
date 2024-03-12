using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickHasCoin : MonoBehaviour
{
    private Animator animator;
    private bool isTouch = false;
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        UpdateAnim();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isTouch = true;
        
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isTouch = false;

        }
    }
    private void UpdateAnim()
    {
        animator.SetBool(Constant.AnimTouchBrick, isTouch);
    }
}
