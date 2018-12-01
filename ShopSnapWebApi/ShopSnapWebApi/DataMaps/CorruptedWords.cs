using System.Collections.Generic;

namespace ShopSnapWebApi.DataMaps
{
    public static class CorruptedWords
    {
        public static Dictionary<string, string> words = new Dictionary<string, string>()
        {
            { "NIJOLAIDA", "NUOLAIDA" },
            { "IJ", "U"}
        };

        public static Dictionary<string, string> numbers = new Dictionary<string, string>()
        {
            { "o", "0" },
            { "I", "1" },
            { "l", "1" },
        };

        public static Dictionary<string, string> letters = new Dictionary<string, string>()
        {
            { "1", "I" },
            { "2", "Z" },
            { "É", "E" },
        };
    }
}
