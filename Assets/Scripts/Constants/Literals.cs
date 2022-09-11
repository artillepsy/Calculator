using System.Collections.Generic;

namespace Constants
{
    public static class Literals
    {
        public const string FileName = "InputData";
        public const char DivideSymbol = '/';
        public static List<char> AllowedSymbols => 
            new List<char>() {'1', '2', '3', '4', '5', '6', '7', '8', '9', '0', DivideSymbol};
    }
}