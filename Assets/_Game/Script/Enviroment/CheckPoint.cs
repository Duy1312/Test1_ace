using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    private Animator m_Animator;
    private bool isMoving;

    private void Start()
    {
        m_Animator = GetComponent<Animator>();
    }
    private void Update()
    {
        m_Animator.SetBool(Constant.AnimMovingPoint, isMoving);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<Player>().SavePoint();
            isMoving = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isMoving = false;
        }
    }
}
