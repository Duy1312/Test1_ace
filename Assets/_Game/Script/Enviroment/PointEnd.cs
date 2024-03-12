using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointEnd : MonoBehaviour
{
    [SerializeField] private int scoreIncrease = 10;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            PlayerScore.Instance.CountScore(scoreIncrease);
        }
    }
}
