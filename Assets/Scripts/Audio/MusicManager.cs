using System;
using GameEvents.Game;
using GameEvents.Generic;
using UnityEngine;

namespace Audio
{
    public class MusicManager : MonoBehaviour, IGameEventListener
    {
        [SerializeField] private GameEvent enterNewAreaEvent;
        [SerializeField] private AudioSource[] musicSources;
        [SerializeField] private float maxVolume = 1f;

        private int currentSource;
        private bool blending;
        
        private void Start()
        {
            enterNewAreaEvent.RegisterListener(this);
            musicSources[0].volume = maxVolume;
        }
        
        public void RaiseGameEvent()
        {
            currentSource += 1;
            blending = true;
        }

        private void Update()
        {
            if (blending)
            {
                musicSources[currentSource].volume += Time.deltaTime/2;
                if (musicSources[currentSource].volume >= maxVolume)
                {
                    blending = false;
                }
            }   
        }

        private void OnDestroy()
        {
            enterNewAreaEvent.UnregisterListener(this);
        }
    }
}