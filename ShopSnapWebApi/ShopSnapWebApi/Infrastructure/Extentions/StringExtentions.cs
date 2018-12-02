using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShopSnapWebApi.Infrastructure.Extentions
{
    public static class StringExtentions
    {
        public static int ConvertStringDecimalToInt(this string str, int multiplier = 100, char separator = ',')
        {
            int result = 0;
            string[] arr = str.Split(separator);
            try
            {
                int euros = int.Parse(arr[0]);
                int cents = int.Parse(arr[1]);
                result = euros * multiplier + cents;
            }
            catch
            {

            }
            return result;
        }
        public static string ReplaceCorruptedValues(this string originalString, Dictionary<string, string> dict)
        {
            foreach (var corruptedPair in dict)
            {
                originalString = originalString.Replace(corruptedPair.Key, corruptedPair.Value);
            }

            return originalString;
        }
        public static string RemoveWhitespace(this string input)
        {
            return new string(input.ToCharArray()
                .Where(c => !char.IsWhiteSpace(c))
                .ToArray());
        }
    }
}