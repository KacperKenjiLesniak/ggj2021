using System;
using Audio;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    public Sound[] sounds;
    public AudioMixerGroup mixer;
    
    private void Awake()
    {
        foreach (var sound in sounds)
        {
            sound.source = gameObject.AddComponent<AudioSource>();
            sound.source.clip = sound.clip;
            sound.source.volume = sound.volume;
            sound.source.pitch = sound.pitch;
            sound.source.playOnAwake = false;
            sound.source.outputAudioMixerGroup = mixer;
        }
    }

    public void Play(string soundName)
    {
        var sound = Array.Find(sounds, sound => sound.name == soundName);
        sound.source.Play();
    }
}