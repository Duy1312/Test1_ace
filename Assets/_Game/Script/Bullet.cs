using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float speed = 10f;
    [SerializeField] private float timetoDestroy = 3f;
    private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime);

        Invoke(nameof(OnDespawn), 1f);
    }
   public void OnDespawn()
    {
        rb.velocity = Vector2.zero;
        Destroy(gameObject);
    }
   
}
