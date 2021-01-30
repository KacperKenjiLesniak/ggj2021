using UnityEngine;
using UnityEngine.UI;

namespace Obstacles
{
    public class MessageInTheBottle : MonoBehaviour
    {
        [SerializeField] private Image message;
        
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Player"))
            {
                message.enabled = true;
                Invoke(nameof(HideMessage), 4f);
            }
        }

        private void HideMessage()
        {
            message.enabled = false;
            Destroy(gameObject);
        }
    }
}