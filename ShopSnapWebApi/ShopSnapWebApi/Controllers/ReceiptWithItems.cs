using ShopSnapWebApi.Models;
using System.Collections.Generic;

namespace ShopSnapWebApi.Controllers
{
    public class ReceiptWithItems
    {
        public Receipt UserReceipt;
        public List<ReceiptItem> UserReceiptItems;
    }
}