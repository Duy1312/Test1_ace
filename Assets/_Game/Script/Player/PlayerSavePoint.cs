using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSavePoint : MonoBehaviour
{
    private List<GameObject> spawnPoints;
    private Transform spawnPoint;
    private Animator animator;
    private void Start()
    {
        animator = GetComponent<Animator>();
        spawnPoints = new List<GameObject>();
        if (spawnPoint == null)
        {
            spawnPoint = GameObject.FindGameObjectsWithTag("CheckPoint")[0].transform;
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
            spawnPoint = FindCloseRespawn();
            gameObject.transform.position = new Vector3(spawnPoint.position.x, spawnPoint.position.y, spawnPoint.position.z);
            animator.SetBool(Constant.AnimIdle, true);
        }
    }
    private Transform FindCloseRespawn()
    {
        Transform closest = null;

        float cloestDistance = Mathf.Infinity;

        Vector3 currentPosition = transform.position;

        foreach (GameObject t in spawnPoints)
        {
            Vector3 directionToSpawnPoint = t.transform.position - currentPosition;
            float distanceSquared = directionToSpawnPoint.sqrMagnitude;

            if (distanceSquared < cloestDistance)
            {
                closest = t.transform;
                cloestDistance = distanceSquared;
            }
        }

        return closest != null ? closest : null;
    }

}
