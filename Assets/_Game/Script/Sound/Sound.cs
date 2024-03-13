using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Sound
{
    public SoundTags name;
    public AudioClip clip;
    [Range(0f, 1f)] public float volume = 1f;
    [HideInInspector] public float maxVolume;
    public bool isLoop;
    public AudioSource source;
}

public enum SoundTags
{
    MainMenu,
    BackGround1,
    BackGround2,
    BackGround3,
    BackGround4,
    BackGround5,
    BackGround6,
    BackGround7,
    BackGround8,
    BackGround9,
    BackGround10,
    GameOver,
    Win


}