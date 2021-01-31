using UnityEngine;

namespace UI
{
    public class SignalAnimation : MonoBehaviour
    {
        private void Start()
        {
            InvokeRepeating(nameof(PlaySignalAnimation), 2f, 8f);
        }

        private void PlaySignalAnimation()
        {
            GetComponent<Animator>().SetTrigger("Fade");
            GetComponent<AudioSource>().Play();
        }
    }
}