using UnityEngine;

namespace UI
{
    public class SignalAnimation : MonoBehaviour
    {
        [SerializeField] private float firstPing = 2f;
        [SerializeField] private float secondPing = 8f;
        [SerializeField] private float nextPings = 20f;
        
        private void Start()
        {
            Invoke(nameof(PlayFirstAnimation), firstPing);
        }

        private void PlayFirstAnimation()
        {
            GetComponent<Animator>().SetTrigger("Fade");
            GetComponent<AudioSource>().Play();
            Invoke(nameof(PlaySecondAnimation), secondPing);
        }
        
        private void PlaySecondAnimation()
        {
            InvokeRepeating(nameof(PlaySignalAnimation), 0f, nextPings);
        }
        
        private void PlaySignalAnimation()
        {
            GetComponent<Animator>().SetTrigger("Fade");
            GetComponent<AudioSource>().Play();
        }
    }
}