using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletHoa : Bullet
{
    protected override void Fire()
    {
        base.Fire();
        rb.velocity = -transform.right * speed;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<PlayerHealth>().hasDied = true;
            Invoke(nameof(OnDespawn), 0.5f);
        }
    }
}
