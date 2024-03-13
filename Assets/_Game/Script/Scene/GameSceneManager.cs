using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameSceneManager : MonoBehaviour
{
    public void MainMenu()
    {
        Time.timeScale = 1.0f;
        SceneManager.LoadScene(SceneEnum.MainMenu.ToString());
        GameManager.Instance.SaveSceneNumbers( LevelScene.currentLevel);
        GameManager.Instance.LoadSceneNumbers();
    }
    public void GoToLevel1()
    {
        Time.timeScale = 1.0f;

        LevelScene.currentLevel = (int)SceneEnum.Level1;

        SceneManager.LoadScene(SceneEnum.Loading.ToString());
        GameManager.Instance.SaveSceneNumbers(LevelScene.currentLevel);
        GameManager.Instance.LoadSceneNumbers();
  
    }
    public void GoToLevel2()
    {
        Time.timeScale = 1.0f;

        LevelScene.currentLevel = (int)SceneEnum.Level2;

        SceneManager.LoadScene(SceneEnum.Loading.ToString());
        GameManager.Instance.SaveSceneNumbers(LevelScene.currentLevel);
        GameManager.Instance.LoadSceneNumbers();

    }
    public void GoToLevel3()
    {
        Time.timeScale = 1.0f;

        LevelScene.currentLevel = (int)SceneEnum.Level3;

        SceneManager.LoadScene(SceneEnum.Loading.ToString());
        GameManager.Instance.SaveSceneNumbers(LevelScene.currentLevel);
        GameManager.Instance.LoadSceneNumbers();
    }
    public void GoToLevel4()
    {
        Time.timeScale = 1.0f;

        LevelScene.currentLevel = (int)SceneEnum.Level4;

        SceneManager.LoadScene(SceneEnum.Loading.ToString());
        GameManager.Instance.SaveSceneNumbers(LevelScene.currentLevel);
        GameManager.Instance.LoadSceneNumbers();
    }
    public void GoToLevel5()
    {
        Time.timeScale = 1.0f;

        LevelScene.currentLevel = (int)SceneEnum.Level5;

        SceneManager.LoadScene(SceneEnum.Loading.ToString());
        GameManager.Instance.SaveSceneNumbers(LevelScene.currentLevel);
        GameManager.Instance.LoadSceneNumbers();
    }
    
    public void GoToLevel6()
    {
        Time.timeScale = 1.0f;

        LevelScene.currentLevel = (int)SceneEnum.Level6;

        SceneManager.LoadScene(SceneEnum.Loading.ToString());
        GameManager.Instance.SaveSceneNumbers(LevelScene.currentLevel);
        GameManager.Instance.LoadSceneNumbers();
    }
    public void GoToLevel7()
    {
        Time.timeScale = 1.0f;

        LevelScene.currentLevel = (int)SceneEnum.Level7;

        SceneManager.LoadScene(SceneEnum.Loading.ToString());
        GameManager.Instance.SaveSceneNumbers(LevelScene.currentLevel);
        GameManager.Instance.LoadSceneNumbers();
    }
    public void GoToLevel8()
    {
        Time.timeScale = 1.0f;

        LevelScene.currentLevel = (int)SceneEnum.Level8;

        SceneManager.LoadScene(SceneEnum.Loading.ToString());
        GameManager.Instance.SaveSceneNumbers(LevelScene.currentLevel);
        GameManager.Instance.LoadSceneNumbers();
    }
    public void GoToLevel9()
    {
        Time.timeScale = 1.0f;

        LevelScene.currentLevel = (int)SceneEnum.Level9;

        SceneManager.LoadScene(SceneEnum.Loading.ToString());
        GameManager.Instance.SaveSceneNumbers(LevelScene.currentLevel);
        GameManager.Instance.LoadSceneNumbers();
    }
    public void GoToLevel10()
    {
        Time.timeScale = 1.0f;

        LevelScene.currentLevel = (int)SceneEnum.Level9;

        SceneManager.LoadScene(SceneEnum.Loading.ToString());
        GameManager.Instance.SaveSceneNumbers(LevelScene.currentLevel);
        GameManager.Instance.LoadSceneNumbers();
    }
}
