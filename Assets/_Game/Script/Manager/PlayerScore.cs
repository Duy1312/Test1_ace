using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerScore : SingleTon<PlayerScore>
{
   
    [SerializeField] private TMP_Text scoreText;
    [SerializeField] private TMP_Text timerLeftText;
    protected float timerLeft = 120f;
    protected int score = 0;

    private void Update()
    {
        timerLeft -= Time.deltaTime;
        scoreText.text = score.ToString();
        timerLeftText.text = timerLeft.ToString();
        if(timerLeft < 0.1f)
        {
            UIManager.Instance.GameOver();
        }
    }
    public void CountScore(int ScoreIncrese)
    {
        score = score + ScoreIncrese;
    }

}
