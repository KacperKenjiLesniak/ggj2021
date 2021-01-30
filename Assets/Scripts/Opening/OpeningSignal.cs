using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Opening
{
    public class OpeningSignal : MonoBehaviour
    {
        [SerializeField] private Transform signal;
        [SerializeField] private Vector2 target;
        [SerializeField] private Image background;
        [SerializeField] private TMP_Text text;

        private Vector3 screenPos;
        private Vector2 onScreenPos;
        private float max;
        private Camera camera;
        private bool moving;
        private bool fading;
        
        void Start()
        {
            camera = Camera.main;

            screenPos = camera.WorldToViewportPoint(signal.position);
            onScreenPos = new Vector2(screenPos.x - 0.5f, screenPos.y - 0.5f) * 2;
            max = Mathf.Max(Mathf.Abs(onScreenPos.x), Mathf.Abs(onScreenPos.y));
            onScreenPos = (onScreenPos / (max * 2)) + new Vector2(0.5f, 0.5f);

            target = new Vector2(onScreenPos.x * 1920 - 960, onScreenPos.y * 1080 - 540);
            
            Invoke(nameof(StartMoving), 3f);
            Invoke(nameof(StartFading), 6f);
        }

        void Update()
        {
            if (moving)
            {
                GetComponent<RectTransform>().anchoredPosition = Vector2.MoveTowards(
                    GetComponent<RectTransform>().anchoredPosition,
                    target,
                    Time.deltaTime * 400f
                );
            }

            if (fading)
            {
                var tempColor = GetComponent<Image>().color;
                tempColor.a -= Time.deltaTime/3;
                GetComponent<Image>().color = tempColor;
                
                var tempColor2 = background.color;
                tempColor2.a -= Time.deltaTime/3;
                background.color = tempColor2;

                text.alpha -= Time.deltaTime/3;
            }
        }

        void StartMoving()
        {
            moving = true;
        }
        
        void StartFading()
        {
            fading = true;
        }
    }
}