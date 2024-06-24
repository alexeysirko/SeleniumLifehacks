using System;
using System.Text.RegularExpressions;

namespace ExampleProject.Framework.Utils
{
    internal class StringUtils
    {
        private const string CurrencyRegex = "[^\\d.]";

        public static double GetDoubleFromString(string value)
        {
            return Convert.ToDouble(Regex.Replace(value, CurrencyRegex, "").Replace(".", ","));
        }
    }
}
