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

        private int currentSource;
        private bool blending;
        
        private void Start()
        {
            enterNewAreaEvent.RegisterListener(this);
            musicSources[0].volume = 1f;
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
                musicSources[currentSource].volume += Time.deltaTime;
                if (musicSources[currentSource].volume >= 1f)
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