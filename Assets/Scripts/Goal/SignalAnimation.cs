using System;
using UnityEditor.Timeline.Actions;
using UnityEngine;

namespace UI
{
    public class SignalAnimation : MonoBehaviour
    {
        private void Start()
        {
            InvokeRepeating(nameof(PlaySignalAnimation), 0f, 8f);
        }

        private void PlaySignalAnimation()
        {
            GetComponent<Animator>().SetTrigger("Fade");
            GetComponent<AudioSource>().Play();
        }
    }
}