using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class UIManager : SingleTon<UIManager> 
{
    [SerializeField] private GameObject gameoverUI;

    public void GameOver()
    {
        gameoverUI.SetActive(true);
        Time.timeScale = 0.0f;
    }
    public void StartOver()
    {
        gameoverUI.SetActive(false);
        Time.timeScale = 1.0f;
    }
}
