using UnityEngine;
using Random = UnityEngine.Random;

namespace Obstacles
{
    public class SplashAnimation : MonoBehaviour
    {
        private void Start()
        {
            var anim = GetComponent<Animator>();
            var randomIdleStart = Random.Range(0,anim.GetCurrentAnimatorStateInfo(0).length);
            anim.Play("Splash1", 0, randomIdleStart);
        }
    }
}