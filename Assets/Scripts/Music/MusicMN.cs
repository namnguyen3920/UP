using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public enum SoundType
{
    Theme,
    Jump,
    CoinCollected
}
public class MusicMN : Singleton_Mono_Method<MusicMN>
{
    /*public Dictionary<SoundType, AudioClip> musicSounds, sfxSounds;*/
    public Sound[] musicSounds, sfxSounds;
    public AudioSource musicSource, sfxSource;

    private void Start()
    {
        PlayMusic(SoundType.Theme);
    }
    public void PlayMusic(SoundType name)
    {
        Sound s = Array.Find(musicSounds, x => x.name == name);
        /*Sound s = Dictionary<SoundType, musicSounds>.ValueCollection[name];*/
        /*var musicSound = musicSounds.Values;
        SoundType soundType;
        AudioClip s = musicSound.FirstOrDefault(sound => sound.Equals(name, soundType);*/

        if (s == null)
        {
            Debug.Log(name + "Sound not found");
        }
        else
        {
            musicSource.clip = s.clip;
            musicSource.Play();
        }
    }
    public void PlaySFX(SoundType name)
    {
        Sound s = Array.Find(sfxSounds, x => x.name == name);

        if (s == null)
        {
            Debug.Log(name + "Sound not found");
        }else
        {
            sfxSource.PlayOneShot(s.clip);
        }
    }
    public void ToggleMusic() { musicSource.mute = !musicSource.mute; }
    public void ToggleSFX() { sfxSource.mute = !sfxSource.mute; }
    public void MusicVolume(float volume) { musicSource.volume = volume;}
    public void SFXVolume(float volume) { sfxSource.volume = volume; }
}
