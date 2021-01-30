using System;
using Audio;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public Sound[] sounds;

    private void Awake()
    {
        foreach (var sound in sounds)
        {
            sound.source = gameObject.AddComponent<AudioSource>();
            sound.source.clip = sound.clip;
            sound.source.volume = sound.volume;
            sound.source.pitch = sound.pitch; 
        }
    }

    public void Play(string soundName)
    {
        var sound = Array.Find(sounds, sound => sound.name == soundName);
        sound.source.Play();
    }
}