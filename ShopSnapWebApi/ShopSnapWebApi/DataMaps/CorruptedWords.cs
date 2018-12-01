using System;
using System.Collections.Generic;

namespace ShopSnapWebApi.DataMaps
{
    public static class WordMaps
    {
        private static Dictionary<string, string> words = new Dictionary<string, string>()
        {
            { "NIJOLAIDA", "NUOLAIDA" }
        };

        public static string ByKey(string key)
        {
            string value = null;

            words.TryGetValue(key, out value);

            return value;
        }
    }
}
