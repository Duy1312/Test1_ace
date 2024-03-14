using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    [SerializeField]  private GameObject anim;
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            PlayerScore.Instance.CountCoin(10);
            anim.gameObject.SetActive(true);
            Destroy(gameObject);
        }
    }

}
