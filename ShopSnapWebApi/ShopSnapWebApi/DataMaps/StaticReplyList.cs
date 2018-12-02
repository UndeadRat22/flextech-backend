using ShopSnapWebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShopSnapWebApi.DataMaps
{
    public class StaticReplyList
    {
        public static List<FoundItem> ItemList = new List<FoundItem>()
        {
            new FoundItem()
            {
                Name = "AVIZINIAI DRIBSNIAI",
                PriceInCents = 78,
                DiscountInCents = 23,
                Amount = 1
            },
            new FoundItem()
            {
                Name = "SAULEGRAZU BRANDUOLIAI",
                PriceInCents = 129,
                DiscountInCents = 40,
                Amount = 1
            },
            new FoundItem()
            {
                Name = "DILMAH LADY SILVER 20",
                PriceInCents = 149,
                DiscountInCents = 45,
                Amount = 1
            },
        };
    }
}