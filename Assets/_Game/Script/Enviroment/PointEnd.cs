using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PointEnd : MonoBehaviour
{
    [SerializeField] private int id;
    [SerializeField] private TMP_Text textPrefab;
    [SerializeField] private GameObject textGameObject;
    [SerializeField] private int scoreIncrease = 10;
    public bool isCollect {  get; private set; }
    private void Start()
    {
        isCollect = false;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && !isCollect)
        {
            textGameObject.SetActive(true);
            textGameObject.GetComponent<TextAnim>().enabled = true;
            textPrefab.text ="+" + scoreIncrease.ToString();
            isCollect = true;
            PlayerScore.Instance.CountScore(scoreIncrease);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        StartCoroutine(OnDespawn());
    }
     IEnumerator OnDespawn()
    {
        yield return new WaitForSeconds(0.5f);
        textGameObject.SetActive(false);
    }
}
