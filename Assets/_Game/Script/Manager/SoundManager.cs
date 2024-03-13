using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : SingleTon<SoundManager> 
{
    public Sound[] sounds;
    private void Awake()
    {
        foreach (Sound sound in sounds)
        {
            InitializeSound(sound);
        }
    }
    void InitializeSound(Sound sound)
    {
        sound.source = gameObject.AddComponent<AudioSource>();
        sound.source.clip = sound.clip;
        sound.maxVolume = sound.volume;

        sound.source.volume = sound.volume;
        sound.source.loop = sound.isLoop;
        sound.source.playOnAwake = false;
     
    }
    public void PlaySound(SoundTags name)
    {
        Sound sound = GetSoundByName(name);

        if (sound == null)
        {
            Debug.LogError("Sound " + name + " not found!");
            return;
        }

       sound.source.Play();
    }
    private Sound GetSoundByName(SoundTags name)
    {
        return Array.Find(sounds, s => s.name == name);
    }
   
    public void StopSound(SoundTags name)
    {
        Sound sound = GetSoundByName(name);

        if (sound == null)
        {
            Debug.LogError("Sound " + name + " not found!");
            return;
        }

        if (sound.source.isPlaying) sound.source.Stop();
    }
}
