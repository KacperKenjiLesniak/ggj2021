using System;
using UnityEngine;

namespace UI
{
    public class DistressSignalSource : MonoBehaviour
    {
        [SerializeField] private Transform arrow;
        [SerializeField] private GameObject nextDistressSignal;

        private Vector3 screenPos;
        private Vector2 onScreenPos;
        private float max;
        private Camera camera;

        void Start()
        {
            camera = Camera.main;
        }

        void Update()
        {
            screenPos = camera.WorldToViewportPoint(transform.position);

            if (screenPos.x >= 0 && screenPos.x <= 1 && screenPos.y >= 0 && screenPos.y <= 1)
            {
                arrow.gameObject.SetActive(false);
                return;
            }

            onScreenPos = new Vector2(screenPos.x - 0.5f, screenPos.y - 0.5f) * 2;
            max = Mathf.Max(Mathf.Abs(onScreenPos.x), Mathf.Abs(onScreenPos.y));
            onScreenPos = (onScreenPos / (max * 2)) + new Vector2(0.5f, 0.5f);
            var arrowPos = camera.ViewportToWorldPoint(new Vector3(onScreenPos.x, onScreenPos.y, 0f));
            arrow.position = new Vector3(arrowPos.x, arrowPos.y, 0f);
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Player"))
            {
                if (nextDistressSignal != null)
                {
                    nextDistressSignal.SetActive(true);
                    enabled = false;    
                }
                else
                {
                    Debug.Log("End animation");
                }
            }
        }
    }
}