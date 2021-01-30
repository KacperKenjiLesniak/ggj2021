using System;
using MutableObjects.Int;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Boat
{
    public class BoatCollision : MonoBehaviour
    {
        [SerializeField] private MutableInt boatHealth;
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
                    Debug.Log("Boat health: " + boatHealth.Value);
                }
            }
        }
    }
}