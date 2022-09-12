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
                return string.Empty;

            return CalculateExpression(digits[0], digits[1]);
        }

        private static bool ValidateExpression(string expression, out int[] result, Action<string> onFailedCallback)
        {
            result = new []{0, 0};
            
            return ExpressionValidation.CheckForEmptyString(expression) &&
                   ExpressionValidation.CheckChars(expression, onFailedCallback) &&
                   ExpressionValidation.CheckForDividerPosition(expression, onFailedCallback) &&
                   ExpressionValidation.TryConvertStringToDigits(expression, out result, onFailedCallback) &&
                   ExpressionValidation.CheckForDivisionByZero(result, onFailedCallback);
        }

        private static string CalculateExpression(int first, int second)
        {
            return ((float) first / second).ToString();
        }
    }
}