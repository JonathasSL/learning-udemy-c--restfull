using System;
using System.Text.RegularExpressions;

namespace WebApplication1.Extensions
{
    public static class StringExtensions
    {
        public static bool IsNumeric(this string value)
        {
            var isNumber = double.TryParse(
                value,
                System.Globalization.NumberStyles.Any,
                System.Globalization.NumberFormatInfo.InvariantInfo,
                out _);

            return isNumber;
        }

        public static decimal ConvertToDecimal(this string value)
        {
            if (decimal.TryParse(value, out var output))
                return output;
            else
                return 0;
        }

        public static bool IsEmptyOrNull(this string value)
        {
            if (value != null)
                return Regex.IsMatch(value, @"^\s$");
            else 
                return true;
        }
    }
}
