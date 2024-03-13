using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class UIManager : SingleTon<UIManager> 
{
    public PlayerSavePoint playerSavePoint;
    public PlayerHealth playerHealth;
    [SerializeField] private GameObject gameoverUI;

    private void Start()
    {
       // playerSavePoint = GameObject.FindWithTag("Player").GetComponent<PlayerSavePoint>();
    }
    public void GameOver()
    {
        gameoverUI.SetActive(true);
        Time.timeScale = 0.0f;
    }
    public void StartOver()
    {
        gameoverUI.SetActive(false);
        playerSavePoint.Reborn();
        playerHealth.Death = false;
        playerHealth.hasDied = false;
        playerHealth.GetComponent<CapsuleCollider2D>().enabled = true;

        playerHealth.GetComponent<Animator>().SetTrigger(Constant.AnimIdle);

        playerHealth.GetComponent<Rigidbody2D>().gravityScale = 3.0f;
        Time.timeScale = 1.0f;
    }
}
