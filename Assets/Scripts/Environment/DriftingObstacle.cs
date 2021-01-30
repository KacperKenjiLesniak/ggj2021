using UnityEngine;
using Random = UnityEngine.Random;

namespace Obstacles
{
    public class DriftingObstacle : MonoBehaviour
    {
        [SerializeField] private float randomForceStrength;
        
        private void Start()
        {
            GetComponent<Rigidbody2D>().AddForce(new Vector2(Random.Range(-randomForceStrength, randomForceStrength), Random.Range(-randomForceStrength, randomForceStrength)));
        }
    }
}