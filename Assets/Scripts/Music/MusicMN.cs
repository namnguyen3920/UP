using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicMN : Singleton_Mono_Method<MusicMN>
{
    [SerializeField] AudioSource music_source;
    public AudioClip background;
    private void Start()
    {
        PlayBackGroundTheme();
    }
    void PlayBackGroundTheme()
    {
        music_source.clip = background;
        music_source.Play();
    }
    
}
