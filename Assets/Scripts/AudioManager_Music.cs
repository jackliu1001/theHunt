using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager_Music : MonoBehaviour
{
    [SerializeField] AudioSource audioSource;
    private float defaultVolume;
    [SerializeField] bool loopMusic;

    // Start is called before the first frame update
    void Start()
    {
        defaultVolume = audioSource.volume;
        UpdateVolume();
    }
    private void Update()
    {
        if(!audioSource.isPlaying && loopMusic)
        {
            audioSource.Play();
        }
    }

    public void UpdateVolume()
    {
        audioSource.volume = defaultVolume * AudioHandler.Singleton.MasterVolume * AudioHandler.Singleton.MusicVolume;
    }
}
