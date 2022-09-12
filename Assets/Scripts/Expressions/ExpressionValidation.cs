using System;
using Constants;

namespace Expressions
{
    public static class ExpressionValidation
    {
        public static bool CheckForEmptyString(string expression)
        {
            return !expression.Equals(string.Empty);
        }

        public static bool CheckChars(string expression, Action<string> onFailedCallback)
        {
            var divideSymbolCount = 0;
            foreach (var symbol in expression)
            {
                if (!Literals.AllowedSymbols.Contains(symbol))
                {
                    onFailedCallback?.Invoke(ErrorMessages.InvalidChars);
                    return false;
                }
                if (symbol.Equals(Literals.DivideSymbol))
                    divideSymbolCount++;
            }

            if (divideSymbolCount < 1)
            {
                onFailedCallback?.Invoke(ErrorMessages.ZeroDividers);
                return false;
            }
            else if (divideSymbolCount > 1)
            {
                onFailedCallback?.Invoke(ErrorMessages.TooManyDividers);
                return false;
            }
            return true;
        }

        public static bool CheckForDividerPosition(string expression, Action<string> onFailedCallback)
        {
            var dividerIndex = expression.IndexOf(Literals.DivideSymbol);
            if (dividerIndex == 0 || dividerIndex == expression.Length - 1)
            {
                onFailedCallback?.Invoke(ErrorMessages.InvalidDividerPosition);
                return false;             
            }
            return true;
        }

        public static bool CheckForDivisionByZero(int[] digits, Action<string> onFailedCallback)
        {
            if (digits[1] != 0) return true;
            onFailedCallback?.Invoke(ErrorMessages.DivideByZero);
            return false;
        }
        
        public static bool TryConvertStringToDigits(string expression, out int[] digits, Action<string> onFailedCallback)
        {
            var stringDigits = expression.Split(Literals.DivideSymbol);
            digits = new int[stringDigits.Length];

            for (var i = 0; i < stringDigits.Length; i++)
            {
                try
                {
                    digits[i] = int.Parse(stringDigits[i]);
                }
                catch (OverflowException e)
                {
                    onFailedCallback?.Invoke(ErrorMessages.OverflowException);
                    return false;
                }
                
            }
            return true;
        }
    }
}