using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextAnim : MonoBehaviour
{
    [SerializeField] private Transform a;
    [SerializeField] private Transform b;
    [SerializeField] private float speed = 5f;
    public Vector3 target;


    void Start()
    {
        transform.position = a.position;
        target = b.position;
    }

    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);
       
        StartCoroutine(OnDespawn());
    }
    private IEnumerator OnDespawn()
    {
        yield return new WaitForSeconds(0.5f);
    }
}
