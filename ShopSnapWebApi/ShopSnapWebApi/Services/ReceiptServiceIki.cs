using ShopSnapWebApi.Infrastructure.Extentions;
using ShopSnapWebApi.Models;
using ShopSnapWebApi.Services.Abstract;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using ShopSnapWebApi.DataMaps;
using System.Diagnostics;

namespace ShopSnapWebApi.Services
{
    public class ReceiptServiceIki : IReceiptService
    {
        private const string _pvmLinePattern = "P\x20*V\x20*M";
        private const string _itemListEndPattern = "Prekiautojo";
        private const string _itemListEndPattern2 = @"Prek.*\s*ID";
        private const string _mainLinePattern = @"([A-ZÉa-z0-9\x20]*).*(\d+,\d\d)";
        private const string _kgLinePattern = @"\t(.*)kg\x20*x(.*)EUR.*\t";
        private const string _wordPattern = @"\x20[A-Z]*[0-9]*[A-Z]";

        ProductRecognitionService _recognitionService;

        public ReceiptServiceIki(ProductRecognitionService recognitionService)
        {
            _recognitionService = recognitionService;
        }

        public List<FoundItem> GetItemList(OcrResponse rawResponse)
        {
            string[] arr = GetReceiptItemStrings(rawResponse);

            List<FoundItem> found = new List<FoundItem>();
            if (arr == null || arr.Length == 0)
                return found;
            FoundItem prev = null;
            foreach (string line in arr)
            {
                if (prev == null)
                {
                    prev = GetItemFromLine(line);
                    if (prev != null)
                        AddPricePerKgFromLine(line, ref prev);
                    continue;
                }
                AddDiscountFromLine(line, ref prev);
                found.Add(prev);
                if (prev.DiscountInCents == 0)
                    prev = GetItemFromLine(line);
                else
                {
                    prev = null;
                }
            }
            return found;
        }

        private FoundItem GetItemFromLine(string line)
        {
            if (line.Contains("NUOLAIDA"))
                return null;
            Match currMatch = Regex.Match(line, _mainLinePattern);
            if (!currMatch.Success)
                return null;
            string name = currMatch.Groups[1].Value;

            if (Regex.IsMatch(name, _wordPattern))
                name = name.ReplaceCorruptedValues(CorruptedWords.letters);
            Product result = _recognitionService.Recognize(name);
            if (result != null)
            {
                name = result.Name;
            }
            string price = currMatch.Groups[2].Value;
            FoundItem item = new FoundItem()
            {
                Name = name,
                PriceInCents = price.ConvertStringDecimalToInt()
            };
            return item;
        }

        private void AddPricePerKgFromLine(string line, ref FoundItem item)
        {
            Match match = Regex.Match(line, _kgLinePattern);
            if (match.Success)
            {
                var amount = match.Groups[1].Value
                    .RemoveWhitespace()
                    .ReplaceCorruptedValues(CorruptedWords.numbers)
                    .ConvertStringDecimalToInt(1000, '.');
                var price = match.Groups[2].Value
                    .RemoveWhitespace()
                    .ReplaceCorruptedValues(CorruptedWords.numbers)
                    .ConvertStringDecimalToInt(100, '.');
                item.PriceInCents = price;
                item.Amount = amount;
                item.PayingForKilo = true;
            }
        }

        private void AddDiscountFromLine(string line, ref FoundItem item)
        {
            if (line == null || !line.Contains("NUOLAIDA") || item == null)
                return;
            Match nextMatch = Regex.Match(line, _mainLinePattern);
            if (!nextMatch.Success)
                return;
            item.DiscountInCents = nextMatch.Groups[2].Value.ConvertStringDecimalToInt();
        }

        public string[] GetReceiptItemStrings(OcrResponse response)
        {
            string[] lines = null;
            string text = null;
            foreach (var result in response.ParsedResults)
            {
                text = result.ParsedText;
                text = text.ReplaceCorruptedValues(CorruptedWords.words);
                lines = text.Split(new string[] { "\n", "\r" }, System.StringSplitOptions.RemoveEmptyEntries);
            }
            lines = GetItemStringArray(lines);
            string unsplit = lines.Aggregate("", (prev, next) => {
                prev += next;
                return prev;
            });

            string[] arr = unsplit
                .Split(new string[] { " A " }, System.StringSplitOptions.RemoveEmptyEntries)
                .Select(ln => ln.Trim())
                .Where(ln => ln != string.Empty)
                .ToArray();

            return arr;
        }

        private string[] GetItemStringArray(string[] allLines){
            int startIndex = GetPatternIndex(allLines, _pvmLinePattern);
            string[] temp = allLines.SubArray(startIndex + 1, allLines.Length - startIndex - 1);
            int endIndex = GetPatternIndex(temp, _itemListEndPattern);
            if (endIndex == 0)
                GetPatternIndex(temp, _itemListEndPattern2);
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

    }
}