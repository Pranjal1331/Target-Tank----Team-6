using System.Collections;
using System.Collections.Generic;
using UnityEngine.Audio;
using UnityEngine;
using System;


public class AudioManager : MonoBehaviour
{
    #region Variables
    public AudioMixerGroup musicmixergroup;
    public AudioMixerGroup sfxmixergroup;
    public Sound[] sounds;
    #endregion
    #region Methods
    void Awake()
    {
        foreach(Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
            s.source.spatialBlend = s.spatialBlend;

            switch (s.audioType)
            {
                case Sound.AudioTypes.Music:
                    s.source.outputAudioMixerGroup = musicmixergroup;
                    break;
                case Sound.AudioTypes.SFX:
                    s.source.outputAudioMixerGroup = sfxmixergroup;
                    break;
                default:
                    break;
            }
        }
    }

    public void Start()
    {
        Play("Theme");
        Play("Tanktrack");
    }
    
    public void Play(String name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        s.source.Play();
    }
    public void Stop(String name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        s.source.Stop();
    }
    public void Resume(String name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        s.source.UnPause();
    }
    public void Pause(String name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        s.source.Pause();
    }
    #endregion
}
