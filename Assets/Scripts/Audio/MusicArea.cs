using System;
using GameEvents.Game;
using UnityEngine;

namespace Audio
{
    public class MusicArea : MonoBehaviour
    {
        [SerializeField] private GameEvent enterNewAreaEvent;

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Player"))
            {
                enterNewAreaEvent.RaiseGameEvent();
                enabled = false;
            }
        }
    }
}