using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletPlayer : Bullet
{
    protected override void Fire()
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime);
    }

   
}
