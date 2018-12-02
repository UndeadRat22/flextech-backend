using ShopSnapWebApi.Models;
using System.Collections.Generic;

namespace ShopSnapWebApi.Repositories
{
    public class ReceiptWithFoundItems
    {
        public int ID { get; set; }
        public int StoreID { get; set; }
        public string Date { get; set; }
        public int UserID { get; set; }

        public List<FoundItem> ReceiptFoundItems { get; set; }
    }
}