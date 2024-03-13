using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickHasCoin : MonoBehaviour
{
    private Animator animator;
    private bool isTouch = false;
    [SerializeField] private int numberToGetCoin = 3;
    private bool isPermanentTouch = false;

    void Start()
    {
        animator = GetComponent<Animator>();
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
            numberToGetCoin--;
            PlayerScore.Instance.CountCoin(10);

            if (numberToGetCoin == 0)
            {
                isPermanentTouch = true;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        isTouch = false;
    }

    private void UpdateAnim()
    {
        animator.SetBool(Constant.AnimTouchBrick, isTouch);
    }
}