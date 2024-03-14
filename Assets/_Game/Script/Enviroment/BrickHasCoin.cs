using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickHasCoin : MonoBehaviour
{
    [SerializeField] private GameObject coinPop;
    private Animator animator;
    private bool isTouch = false;
    [SerializeField] private int numberToGetCoin = 3;
    private bool isPermanentTouch = false;
    private Animator coinAnim;
    void Start()
    {

        animator = GetComponent<Animator>();
        coinAnim = coinPop.GetComponent<Animator>();
    }

    void Update()
    {
        UpdateAnim();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && !isTouch && !isPermanentTouch)
        {
            isTouch = true;
          
            PlayerScore.Instance.CountCoin(10);
            coinAnim.Play("CoinUp");
         
         
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player")&& isTouch == true)
        {
            if (numberToGetCoin > 0)
            {
                isTouch = false;
                numberToGetCoin--;
                if (numberToGetCoin == 0)
                {
                    isPermanentTouch = true;
                    isTouch = false;
                 
                }
            }

        }
    
      
    }

    private void UpdateAnim()
    {
        animator.SetBool(Constant.AnimTouchBrick, isTouch);
        if(numberToGetCoin == 0)
        {
        
            animator.SetTrigger("done");
        }
    }

}