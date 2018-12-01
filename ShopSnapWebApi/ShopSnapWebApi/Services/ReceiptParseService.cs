using ShopSnapWebApi.Infrastructure.Extentions;
using ShopSnapWebApi.Models;
using ShopSnapWebApi.Services.Abstract;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace ShopSnapWebApi.Services
{
    public class ReceiptParseService : IReceiptService
    {
        private const string _pvmLinePattern = "P\x20*V\x20*M";
        private const string _itemListEndPattern = "Prekiautojo";
        private const string _quoteLinePattern = "\\r\\n[A-ZÉ0-9 ]*\\t*(, ,)[A-ZÉ0-9 ]*\\t[0-9, ]*A";

        public List<FoundItem> GetItemList(OcrResponse rawResponse)
        {
            return null;
        }

        public string[] GetReceiptItems(OcrResponse response)
        {
            List<FoundItem> items = new List<FoundItem>();
            string[] lines = null;
            string text = null;
            foreach (var result in response.ParsedResults)
            {
                text = result.ParsedText;
                FoundItem item = new FoundItem();

                string[] splits = { "\n", "\r" };
                lines = text.Split(splits, System.StringSplitOptions.RemoveEmptyEntries);
            }
            return GetItemStringArray(lines);
        }
        private string[] GetItemStringArray(string[] allLines){
            int startIndex = GetPatternIndex(allLines, _pvmLinePattern);
            string[] temp = allLines.SubArray(startIndex + 1, allLines.Length - startIndex - 1);
            int endIndex = GetPatternIndex(temp, _itemListEndPattern);
            string[] result = temp.SubArray(0, endIndex);
            return result;
        }
        private int GetPatternIndex(string[] allLines, string pattern)
        {
            int index = 0;
            for (int i = 0; i < allLines.Length; i++)
            {
                string line = allLines[i];
                if (Regex.IsMatch(line, pattern))
                {
                    index = i;
                    break;
                }
            }
            return index;
        }
        //private List<string> TryGetNormalLines(string parsed)
        private List<string> TryGetLinesWithQuotes(string parsed)
        {
            List<string> matches = new List<string>();
            foreach (Match match in Regex.Matches(parsed, _quoteLinePattern))
            {
                matches.Add(match.Value);
            }
            return matches;
        }
    }
}