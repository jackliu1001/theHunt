using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioHandler : MonoBehaviour
{
    public static AudioHandler Singleton;

    [SerializeField] private string masterVolumeKey = "MasterVolume";
    [SerializeField] private string musicVolumeKey = "musicVolume";
    [SerializeField] private string fxVolumeKey = "fxVolume";

    public float MasterVolume { get { return PlayerPrefs.GetFloat(masterVolumeKey,1); } }
    public float MusicVolume { get { return PlayerPrefs.GetFloat(musicVolumeKey, 1); } }
    public float FXVolume { get { return PlayerPrefs.GetFloat(fxVolumeKey, 1); } }

    private void Awake()
    {
        Singleton = this;
        //if (!Singleton || Singleton == this)
        //{
        //    Singleton = this;
        //    DontDestroyOnLoad(gameObject);
        //}
        //else
        //{
        //    Destroy(gameObject);
        //}
    }

    public void MasterVolumeSlider(float value)
    {
        PlayerPrefs.SetFloat(masterVolumeKey, value);
    }
    public void MusicVolumeSlider(float value)
    {
        PlayerPrefs.SetFloat(musicVolumeKey, value);
    }
    public void FXVolumeSlider(float value)
    {
        PlayerPrefs.SetFloat(fxVolumeKey, value);
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
