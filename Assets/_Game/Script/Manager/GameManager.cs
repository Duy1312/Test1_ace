using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : SingleTon<GameManager> 
{
    private void OnEnable()
    {
        Time.timeScale = 1.0f;
    }

    private void Start()
    {
        PlayMusicAccordingScene();
    }
    public void SaveSceneNumbers (int sceneIndexCurrent)
    {
 
        LevelScene.currentLevel = sceneIndexCurrent;
    
        PlayerPrefs.SetInt("CurrentScene", sceneIndexCurrent);
        PlayerPrefs.Save();
    }
    public void DeleteSaveScene()
    {
        PlayerPrefs.DeleteKey("CurrentScene");

    }
    public void LoadSceneNumbers()
    {
        LevelScene.currentLevel = PlayerPrefs.GetInt("CurrentScene");
    }
    public void PlayMusicAccordingScene()
    {
        if (LevelScene.currentLevel == (int)SceneEnum.Level1)
        {
            SoundManager.Instance.PlaySound(SoundTags.BackGround1);

        }
        else if ((LevelScene.currentLevel == (int)SceneEnum.Level2))
            SoundManager.Instance.PlaySound(SoundTags.BackGround2);
        else if ((LevelScene.currentLevel == (int)SceneEnum.Level3))
        {
            SoundManager.Instance.PlaySound(SoundTags.BackGround3);
        }
        else if ((LevelScene.currentLevel == (int)SceneEnum.Level4))
        {
            SoundManager.Instance.PlaySound(SoundTags.BackGround4);
        }
        else if ((LevelScene.currentLevel == (int)SceneEnum.Level5))
        {
            SoundManager.Instance.PlaySound(SoundTags.BackGround5);
        }
        else if ((LevelScene.currentLevel == (int)SceneEnum.Level6))
        {
            SoundManager.Instance.PlaySound(SoundTags.BackGround6);
        }
        else if ((LevelScene.currentLevel == (int)SceneEnum.Level7))
        {
            SoundManager.Instance.PlaySound(SoundTags.BackGround7);
        }
        else if ((LevelScene.currentLevel == (int)SceneEnum.Level8))
        {
            SoundManager.Instance.PlaySound(SoundTags.BackGround8);
        }
        else if ((LevelScene.currentLevel == (int)SceneEnum.Level9))
        {
            SoundManager.Instance.PlaySound(SoundTags.BackGround9);
        }
        else
        {
            SoundManager.Instance.PlaySound(SoundTags.MainMenu);
        }
    }

    public void StopMusicAccordingScene()
    {
        if (LevelScene.currentLevel == (int)SceneEnum.Level1)
            SoundManager.Instance.StopSound(SoundTags.BackGround1);
        else if ((LevelScene.currentLevel == (int)SceneEnum.Level2))
            SoundManager.Instance.StopSound(SoundTags.BackGround2);
        else if ((LevelScene.currentLevel == (int)SceneEnum.Level3))
        {
            SoundManager.Instance.StopSound(SoundTags.BackGround3);
        }
        else if ((LevelScene.currentLevel == (int)SceneEnum.Level4))
        {
            SoundManager.Instance.StopSound(SoundTags.BackGround4);
        }
        else if ((LevelScene.currentLevel == (int)SceneEnum.Level5))
        {
            SoundManager.Instance.StopSound(SoundTags.BackGround5);
        }
        else if ((LevelScene.currentLevel == (int)SceneEnum.Level6))
        {
            SoundManager.Instance.StopSound(SoundTags.BackGround6);
        }
        else if ((LevelScene.currentLevel == (int)SceneEnum.Level7))
        {
            SoundManager.Instance.StopSound(SoundTags.BackGround7);
        }
        else if ((LevelScene.currentLevel == (int)SceneEnum.Level8))
        {
            SoundManager.Instance.StopSound(SoundTags.BackGround8);
        }
        else if ((LevelScene.currentLevel == (int)SceneEnum.Level9))
        {
            SoundManager.Instance.StopSound(SoundTags.BackGround9);
        }
        else if ((LevelScene.currentLevel == (int)SceneEnum.Level10))
        {
            SoundManager.Instance.StopSound(SoundTags.BackGround10);
        }
        else
        {
            SoundManager.Instance.StopSound(SoundTags.MainMenu);
        }
    }

    private void OnApplicationQuit()
    {
        SaveSceneNumbers(LevelScene.currentLevel);
    }
}
