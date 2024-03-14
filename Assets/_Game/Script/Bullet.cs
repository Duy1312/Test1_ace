using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] protected float speed = 20f;
    [SerializeField] private float timetoDestroy = 3f;

    protected Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Fire();
    }
    // Update is called once per frame
    void Update()
    {
        

        Invoke(nameof(OnDespawn), 1f);
    }
    protected virtual void Fire()
    {

    }
   public void OnDespawn()
    {
        rb.velocity = Vector2.zero;
        Destroy(gameObject);
    }
  
   

}
