using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts
{
    public class FpsComponent : MonoBehaviour
    {
        [SerializeField]
#pragma warning disable 649
        private Text displayText;
#pragma warning restore 649
        [SerializeField]
        private int frameRange;

        private int[] fpsBuffer;
        private int fpsBufferIndex;
        private int averageFPS;

        private void Start()
        {
            InitializeBuffer();
        }

        private void Update()
        {
            UpdateBuffer();
            CalculateFps();
            UpdateFpsView();
        }

        private void InitializeBuffer()
        {
            if (frameRange <= 0)
            {
                frameRange = 1;
            }

            fpsBuffer = new int[frameRange];
            fpsBufferIndex = 0;
        }

        private void UpdateBuffer()
        {
            fpsBuffer[fpsBufferIndex++] = (int)(1f / Time.unscaledDeltaTime);
            if (fpsBufferIndex >= frameRange)
            {
                fpsBufferIndex = 0;
            }
        }

        private void CalculateFps()
        {
            var sum = 0;
            var lowest = int.MaxValue;
            var highest = 0;
            for (var i = 0; i < frameRange; i++)
            {
                var fps = fpsBuffer[i];
                sum += fps;
                if (fps > highest)
                {
                    highest = fps;
                }

                if (fps < lowest)
                {
                    lowest = fps;
                }
            }

            averageFPS = sum / frameRange;
        }

        private void UpdateFpsView()
        {
            displayText.text = averageFPS.ToString();
        }
    }
}
