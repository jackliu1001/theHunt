using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioHandler : MonoBehaviour
{
    public static AudioHandler Singleton;
    [SerializeField] private string masterVolumeKey = "masterVolume";
    [SerializeField] private string musicVolumeKey = "musicVolume";
    [SerializeField] private string FXVolumeKey = "fxVolume";
    [SerializeField] UnityEngine.UI.Slider masterVolumeSlider;
    [SerializeField] UnityEngine.UI.Slider musicVolumeSlider;
    [SerializeField] UnityEngine.UI.Slider fxVolumeSlider;
    private bool setUp;

    public float MasterVolume { get { return PlayerPrefs.GetFloat(masterVolumeKey, 1); } }
    public float MusicVolume { get { return PlayerPrefs.GetFloat(musicVolumeKey, 1); } }
    public float FXVolume { get { return PlayerPrefs.GetFloat(FXVolumeKey, 1); } }

    private void Awake()
    {
        Singleton = this;
        //if (!Singleton || Singleton == this)
        //{
        //    Singleton = this;
        //    DontDestroyOnLoad(gameObject);
        //}
        //else
        //    Destroy(gameObject);
    }

    private void Update()
    {
        if(!setUp)
        {  
            masterVolumeSlider.value = MasterVolume;
            musicVolumeSlider.value = MusicVolume;
            fxVolumeSlider.value = FXVolume;
            setUp = true;
        }
    }

    public void MasterVolumeSlider (float value)
    {
        PlayerPrefs.SetFloat(masterVolumeKey, value);
    }

    public void MusicVolumeSlider(float value)
    {
        PlayerPrefs.SetFloat(musicVolumeKey, value);
    }

    public void FXVolumeSlider(float value)
    {
        PlayerPrefs.SetFloat(FXVolumeKey, value);
    }

    public void MasterVolumeSliderGame(float value)
    {
        MasterVolumeSlider(value);
        updateGameAudioManagers();
    }

    public void MusicVolumeSliderGame(float value)
    {
        MusicVolumeSlider(value);
        updateGameAudioManagers();
    }

    public void FXVolumeSliderGame(float value)
    {
        FXVolumeSlider(value);
        updateGameAudioManagers();
    }

    private void updateGameAudioManagers()
    {
        FindObjectOfType<AudioManager_Music>().UpdateVolume();
        FindObjectOfType<AudioManager_PrototypeHero>().UpdateVolume();
    }
}
