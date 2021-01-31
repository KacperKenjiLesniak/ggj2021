using MutableObjects.Vector3;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Obstacles
{
    public class DriftingObstacle : MonoBehaviour
    {
        [SerializeField] private MutableVector3 boatPosition;
        [SerializeField] private float distanceToActivate = 20f;
        [SerializeField] private float randomForceStrength;

        private bool activated;

        private void Update()
        {
            if (!activated && Vector2.Distance(boatPosition.Value, transform.position) < distanceToActivate)
            {
                GetComponent<Rigidbody2D>().AddForce(new Vector2(Random.Range(-randomForceStrength, randomForceStrength), Random.Range(-randomForceStrength, randomForceStrength)));
                activated = true;
            }

            if (activated && Vector2.Distance(boatPosition.Value, transform.position) > distanceToActivate)
            {
                activated = false;
                GetComponent<Rigidbody2D>().velocity = Vector3.zero;
                GetComponent<Rigidbody2D>().angularVelocity = 0f;
            }
        }
    }
}