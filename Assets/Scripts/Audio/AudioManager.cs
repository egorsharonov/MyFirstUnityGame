using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioManager : MonoBehaviour
{
    public Sound[] sounds;

    public static AudioManager instance;
    private void Awake()
    {

        if (instance==null)
            instance = this;
        else
            Destroy(gameObject);

        DontDestroyOnLoad(gameObject);

        foreach (var sound in sounds)
        {
            sound.source = gameObject.AddComponent<AudioSource>();
            sound.source.clip = sound.clip;

            sound.source.volume = sound.volume;
            sound.source.pitch = sound.pitch;
            sound.source.loop = sound.loop;
        }
    }

    public void Play(string name)
    {
        Sound currentSound = Array.Find(sounds, sound => sound.name == name);
        if (currentSound == null)
        {
            Debug.LogWarning("No such sound: " + name);
            return;
        }

        currentSound.source.Play();
    }
    public void Stop(string name)
    {
        Sound currentSound = Array.Find(sounds, sound => sound.name == name);
        if (currentSound == null)
        {
            Debug.LogWarning("No such sound: " + name);
            return;
        }

        currentSound.source.Stop();
    }
}