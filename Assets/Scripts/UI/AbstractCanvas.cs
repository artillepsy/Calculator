using UnityEngine;

namespace UI
{
    public abstract class AbstractCanvas : MonoBehaviour
    {
        [SerializeField] private GameObject canvas;
        [SerializeField] protected CanvasManager canvasManager;
        
        public void OnClickExit() => Application.Quit();

        public virtual void Show()
        {
            if(!canvas.activeSelf)
                canvas.SetActive(true);
        }

        public virtual void Hide()
        {
            if(canvas.activeSelf)
                canvas.SetActive(false);
        }
    }
}