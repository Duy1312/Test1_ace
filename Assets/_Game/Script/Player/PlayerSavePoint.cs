using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSavePoint : MonoBehaviour
{

    public List<GameObject> spawnPoints;
    public Transform spawnPoint;
    private Animator animator;
    private void Start()
    {
        animator = GetComponent<Animator>();
        spawnPoints = new List<GameObject>();
        if (spawnPoint == null)
        {
            spawnPoint = spawnPoints[0].transform;
            spawnPoints.Add(spawnPoint.gameObject);
      }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("CheckPoint"))
        {
            if (!spawnPoints.Contains(collision.gameObject))
            {
                spawnPoints.Add(collision.gameObject);
            }
        }
    }
    public void Reborn()
    {
        if (spawnPoint != null)
        {
           
                spawnPoint = spawnPoints[spawnPoints.Count - 1].transform;
            
            
            gameObject.transform.position = new Vector3(spawnPoint.position.x, spawnPoint.position.y+ 1f, spawnPoint.position.z);
            animator.SetBool(Constant.AnimIdle, true);
        }
    }
    public void StartPoint()
    {
        if (spawnPoint != null)
        {
            spawnPoint = spawnPoints[0].transform;
            gameObject.transform.position = new Vector3(spawnPoint.position.x, spawnPoint.position.y, spawnPoint.position.z);
            animator.SetBool(Constant.AnimIdle, true);
        }
    }
    

}
