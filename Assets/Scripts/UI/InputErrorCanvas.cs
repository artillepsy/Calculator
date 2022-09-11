using TMPro;
using UnityEngine;

namespace UI
{
    public class InputErrorCanvas : AbstractCanvas
    {
        [SerializeField] private TextMeshProUGUI errorLabel;
        
        public void ShowErrorMessage(string message)
        {
            errorLabel.text = message;
            canvasManager.ShowCanvas(this);
        }
        
        public void OnClickNewEquation()
        {
            canvasManager.ShowLastCanvas();
        }
    }
}