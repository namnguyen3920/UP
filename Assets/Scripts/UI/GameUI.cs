using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class GameUI : MonoBehaviour
{
    public Animator menu_anim;
    private const string FADE_IN = "FadeIn";
    public GameObject menu;
    public Slider musicSlider, sfxSlider;

    public void ActiveSettingMenu()
    {
        menu.SetActive(true);
    }
    public void InactiveSettingMenu()
    {
        StartCoroutine(CoroutineSettingMenu());
    }
    IEnumerator CoroutineSettingMenu()
    {
        AnimationMN.d_Instance.SetTriggerAction(menu_anim, FADE_IN);
        yield return new WaitForSeconds(0.1f);
        menu.SetActive(false);
    }
    public void ToggleMusic()
    {
        MusicMN.d_Instance.ToggleMusic();
    }
    public void ToggleSfx()
    {
        MusicMN.d_Instance.ToggleSFX();
    }
    public void MusicVolume()
    {
        MusicMN.d_Instance.MusicVolume(musicSlider.value);
    }
    public void SFXVolume()
    {
        MusicMN.d_Instance.MusicVolume(sfxSlider.value);
    }
}
