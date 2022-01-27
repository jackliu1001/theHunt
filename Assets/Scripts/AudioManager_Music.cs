using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager_Music : MonoBehaviour
{
    [SerializeField] AudioSource audioSource;
    private float defaultVolume;
    [SerializeField] bool loopMusic;
    private bool setUp;
    // Start is called before the first frame update
    void Start()
    {
        defaultVolume = audioSource.volume;       
    }

    public void UpdateVolume()
    {
        //if(!setUp)
        //{
        //    defaultVolume = audioSource.volume;
        //    setUp = true;
        //}
        audioSource.volume = defaultVolume * AudioHandler.Singleton.MasterVolume * AudioHandler.Singleton.MusicVolume;
    }

    private void Update()
    {
        if(!audioSource.isPlaying && loopMusic)
        {
            audioSource.Play();
        }
    }
}
