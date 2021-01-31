using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class VolumeSlider : MonoBehaviour
{
    [SerializeField] private AudioMixer mixer;

    public void setLevel(float sliderValue)
    {
        mixer.SetFloat("volLevel", Mathf.Log10(sliderValue)*20);
    }
}
