using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundFXCtrl : Singleton_Mono_Method<SoundFXCtrl>
{
    [SerializeField] AudioSource soundFXObj;
    [SerializeField] AudioClip jumpSound; 
    public void PlayFXSound(Transform spawnTransform, float volume)
    {
        AudioSource audioSource = Instantiate(soundFXObj, spawnTransform.position, Quaternion.identity);

        audioSource.clip = jumpSound;
        audioSource.volume = volume;
        audioSource.Play();
        float clipLength = audioSource.clip.length;
        Destroy(audioSource.gameObject, clipLength);
    }
}
