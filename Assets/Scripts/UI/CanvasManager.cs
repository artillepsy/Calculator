using System.Collections.Generic;
using UnityEngine;

namespace UI
{
    public class CanvasManager : MonoBehaviour
    {
        [SerializeField] private List<AbstractCanvas> canvases;
        private AbstractCanvas _lastCanvas;

        public void ShowCanvas(AbstractCanvas canvasToShow)
        {
            if(!canvasToShow)
                Debug.LogError("Canvas to show is null");
            
            foreach (var canvas in canvases)
            {
                if (canvas != canvasToShow)
                {
                    _lastCanvas = canvas;
                    canvas.Hide();
                }
                else
                    canvas.Show();
            }
        }

        public void ShowLastCanvas() => ShowCanvas(_lastCanvas);
    }
}