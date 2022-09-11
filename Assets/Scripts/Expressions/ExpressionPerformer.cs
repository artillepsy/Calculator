using System;
using Constants;
using UnityEngine;

namespace Expressions
{
    public static class ExpressionPerformer
    {
        public static string Calculate(string expression, Action<string> onFailedCallback)
        {
            if(!ValidateExpression(expression, out var digits, onFailedCallback))
                return String.Empty;

            return CalculateExpression(digits[0], digits[1]);
        }

        private static bool ValidateExpression(string expression, out int[] result, Action<string> onFailedCallback)
        {
            result = new []{0, 0};
            Debug.Log(0);
            if (!ExpressionValidation.CheckForEmptyString(expression))
                return false;
            Debug.Log(1);
            if (!ExpressionValidation.CheckChars(expression, onFailedCallback))
                return false;
            Debug.Log(2);
            if (!ExpressionValidation.CheckForDividerPosition(expression, onFailedCallback))
                return false;

            Debug.Log(3);
            if (!ExpressionValidation.ConvertStringToDigits(expression, out result, onFailedCallback))
                return false;
            
            if (!ExpressionValidation.CheckForDivisionByZero(result, onFailedCallback))
                return false;
            Debug.Log(4);
            return true;
        }

        private static string CalculateExpression(int first, int second)
        {
            return ((float) first / second).ToString();
        }
    }
}