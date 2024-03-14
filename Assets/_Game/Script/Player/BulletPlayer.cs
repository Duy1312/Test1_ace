using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletPlayer : Bullet
{

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            OnDespawn();
        }
        rb.velocity = Vector3.zero;
        if (collision.gameObject.CompareTag("Enemy"))
        {
        


            rb.AddForce(Vector2.up  * 3f);
            collision.gameObject.GetComponent<BoxCollider2D>().enabled = false;

            collision.gameObject.GetComponent<Enemy>().Death();
            //   collision.gameObject.GetComponent<Enemy>().enabled = false;
            collision.gameObject.GetComponent<Rigidbody2D>().freezeRotation = false;
            collision.gameObject.GetComponent<Rigidbody2D>().gravityScale = 20f;
            PlayerScore.Instance.CountScore(20);
            OnDespawn();
        }
    }

}
