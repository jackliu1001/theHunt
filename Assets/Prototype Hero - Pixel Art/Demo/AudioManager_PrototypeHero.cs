﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Sound
{
    public string m_name;
    public AudioClip[] m_clips;
    [Range(0f, 1f)]
    public float volume = 1.0f;
    [Range(0f, 1.5f)]
    public float pitch = 1.0f;
    public Vector2 m_randomVolumeRange = new Vector2(1.0f, 1.0f);
    public Vector2 m_randomPitchRange = new Vector2(1.0f, 1.0f);
    public bool m_loop = false;
    public float DefaultVolume;
    private AudioSource m_source;

    

    public void SetSource(AudioSource source)
    {
        m_source = source;
        int randomClip = Random.Range(0, m_clips.Length - 1);
        m_source.clip = m_clips[randomClip];
        m_source.loop = m_loop;
    }

    public void Play()
    {
        if(m_clips.Length > 1)
        {
            int randomClip = Random.Range(0, m_clips.Length - 1);
            m_source.clip = m_clips[randomClip];
        }
        m_source.volume = volume * Random.Range(m_randomVolumeRange.x, m_randomVolumeRange.y);
        m_source.pitch = pitch * Random.Range(m_randomPitchRange.x, m_randomPitchRange.y);
        m_source.Play();
    }

    public void Stop()
    {
        m_source.Stop();
    }

    public bool IsPlaying()
    {
        if (m_source.isPlaying)
            return true;
        else
            return false;
    }
}

public class AudioManager_PrototypeHero : MonoBehaviour
{
    // Make it a singleton class that can be accessible everywhere
    public static AudioManager_PrototypeHero instance;

    [SerializeField]
    Sound[] m_sounds;

    private void Awake()
    {
        if(instance != null)
        {
            Debug.LogError("More than one AudioManger in scene");
        }
        else
        {
            instance = this;
        }
    }

    private void Start()
    {
        for(int i = 0; i < m_sounds.Length; i++)
        {
            GameObject go = new GameObject("Sound_" + i + "_" + m_sounds[i].m_name);
            go.transform.SetParent(transform);
            m_sounds[i].SetSource(go.AddComponent<AudioSource>());
            m_sounds[i].DefaultVolume = m_sounds[i].volume;
        }
        UpdateVolume();
    }

    public void UpdateVolume()
    {
        for(int i =0; i<m_sounds.Length; i++)
        {
            m_sounds[i].volume = AudioHandler.Singleton.FXVolume * AudioHandler.Singleton.MasterVolume;
        }
    }

    public void PlaySound (string name)
    {
        for(int i = 0; i < m_sounds.Length; i++)
        {
            if(m_sounds[i].m_name == name)
            {
                m_sounds[i].Play();
                return;
            }
        }

        Debug.LogWarning("AudioManager: Sound name not found in list: " + name);
    }

    public void StopSound(string name)
    {
        for (int i = 0; i < m_sounds.Length; i++)
        {
            if (m_sounds[i].m_name == name && m_sounds[i].IsPlaying())
            {
                m_sounds[i].Stop();
                return;
            }
        }
    }

    public bool IsPlaying(string name)
    {
        for (int i = 0; i < m_sounds.Length; i++)
        {
            if (m_sounds[i].m_name == name && m_sounds[i].IsPlaying())
            {
                return true;
            }
        }

        return false;
    }
}
