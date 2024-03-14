using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerScore : SingleTon<PlayerScore>
{

    [SerializeField] private TMP_Text coinText;
    [SerializeField] private TMP_Text scoreText;
    [SerializeField] private TMP_Text timerLeftText;

    [SerializeField] private TMP_Text level;
    protected float timerLeft = 120f;
    protected int score = 0;
    protected int coin = 0;
    private void Start()
    {
        score = PlayerPrefs.GetInt("Score");
        coin = PlayerPrefs.GetInt("Coin");


    }
    private void Update()
    {
        timerLeft -= Time.deltaTime;
        scoreText.text = score.ToString();
        PlayerPrefs.SetInt("Score", score);

        coinText.text = coin.ToString();
        PlayerPrefs.SetInt("Coin", coin);

        level.text = GetCurrentScene().ToString();
       int timLeftInt = Mathf.RoundToInt(timerLeft);
        timerLeftText.text = timLeftInt.ToString();
        if(timerLeft < 0.1f)
        {
            UIManager.Instance.GameOver();
        }
    }
    private int GetCurrentScene()
    {
        int currentScene = SceneManager.GetActiveScene().buildIndex +1;
        return currentScene;

    }
    public void CountScore(int ScoreIncrese)
    {
        score = score + ScoreIncrese;
    }
    public void CountCoin(int coinIncrese)
    {
        coin = coin + coinIncrese;
    }
    private void OnApplicationQuit()
    {
        PlayerPrefs.DeleteAll();
    }

}
