using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletHoa : Bullet
{
    protected override void Fire()
    {
        base.Fire();
        transform.Translate(Vector2.left * speed * Time.deltaTime);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<PlayerHealth>().Death = true;
        }
    }
}
