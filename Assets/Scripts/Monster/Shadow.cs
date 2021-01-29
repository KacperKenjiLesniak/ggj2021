using System;
using MutableObjects.Vector3;
using UnityEngine;

namespace Monster
{
    public class Shadow : MonoBehaviour
    {
        [SerializeField] private MutableVector3 boatPosition;
        [SerializeField] private float shadowAttractRadius = 10f;
        [SerializeField] private float shadowFollowRadius = 3f;
        [SerializeField] private float shadowSpeed = 3f;

        private bool following;
        private bool swimmingAway;
        private Vector3 direction;
            
        private void Update()
        {
            var boatDistance = Vector3.Distance(transform.position, boatPosition.Value);
            
            if (!following &&  boatDistance <= shadowAttractRadius)
            {
                following = true;
            }

            if (following)
            {
                if (!swimmingAway && boatDistance > shadowFollowRadius)
                {
                    direction = (boatPosition.Value - transform.position).normalized;
                }
                else
                {
                    swimmingAway = true;
                }
                transform.position += direction * (shadowSpeed * Time.deltaTime);
            }
        }
    }
}