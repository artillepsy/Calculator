using Expressions;
using SaveSystem;
using TMPro;
using UnityEngine;

namespace UI
{
    public class InputCanvas : AbstractCanvas
    {
        [SerializeField] private TMP_InputField expressionInputField;
        [SerializeField] private InputErrorCanvas inputErrorCanvas;

        public void OnClickResult()
        {
            expressionInputField.text = ExpressionPerformer.Calculate(expressionInputField.text,
                inputErrorCanvas.ShowErrorMessage);
        }

        public void OnClickClear()
        {
            expressionInputField.text = string.Empty;
        }

        private void OnApplicationQuit()
        {
            InputDataSaveLoader.SaveInputData(expressionInputField.text);
        }

        private void Awake()
        {
            expressionInputField.text = InputDataSaveLoader.LoadInputData();
            canvasManager.ShowCanvas(this);
        }
    }
}