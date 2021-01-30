using System;
using GameEvents.Game;
using MutableObjects.Int;
using Obstacles;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Boat
{
    public class BoatCollision : MonoBehaviour
    {
        [SerializeField] private MutableInt boatHealth;
        [SerializeField] private GameEvent boatDamagedPlankEvent;
        [SerializeField] private GameEvent boatDamagedStoneEvent;
        [SerializeField] private float collisionSpeedThreshold;

        private void OnCollisionEnter2D(Collision2D other)
        {
            if (other.collider.CompareTag("Obstacle"))
            {
                Debug.Log("Collided with an obstacle");
                Debug.Log("Collision speed: " + other.relativeVelocity.magnitude);
                if (other.relativeVelocity.magnitude > collisionSpeedThreshold)
                {
                    boatHealth.Value -= 1;
                    if (other.gameObject.GetComponent<Stone>())
                    {
                        boatDamagedStoneEvent.RaiseGameEvent();
                    }
                    if (other.gameObject.GetComponent<Plank>())
                    {
                        boatDamagedPlankEvent.RaiseGameEvent();
                    }
                    Debug.Log("Boat health: " + boatHealth.Value);
                }
            }
        }
    }
}