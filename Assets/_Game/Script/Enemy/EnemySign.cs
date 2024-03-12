using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySign : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.GetComponent<Enemy>().SetTargetInRange(collision.GetComponent<Player>());
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {

        if (collision.CompareTag("Player"))
        {
            collision.GetComponent<Enemy>().SetTargetInRange(null);
        }
    }
}
