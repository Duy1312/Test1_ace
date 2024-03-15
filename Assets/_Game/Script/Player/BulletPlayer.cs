using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletPlayer : Bullet
{

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            rb.velocity = new Vector2(rb.velocity.x , 10f);
            StartCoroutine(OnDespawn());
        }

        if (collision.gameObject.CompareTag("Enemy"))
        {

            rb.velocity = Vector3.zero;
            collision.gameObject.GetComponent<Enemy>().Death();

            PlayerScore.Instance.CountScore(20);

            rb.AddForce(Vector2.up  * 3f);

            StartCoroutine(OnDespawn());
        }
    }

}
