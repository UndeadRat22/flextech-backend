using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShopSnapWebApi.Models
{
    public class FoundItem
    {
        public string Name { get; set; }
        public bool PayingForKilo { get; set; }
        public int PriceInCents { get; set; }
        public int Amount { get; set; }
    }
}