using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] protected float speed = 20f;
    [SerializeField] private float timetoDestroy = 3f;
    [SerializeField] public LayerMask whatisGround;
    protected Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Fire();
    }

   
    protected virtual void Fire()
    {

    }
   public IEnumerator OnDespawn()
    {
        yield return new WaitForSeconds(.8f);
       
        Destroy(gameObject);
    }
  
   

}
