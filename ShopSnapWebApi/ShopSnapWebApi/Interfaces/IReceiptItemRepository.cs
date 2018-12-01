using System.Collections.Generic;
using ShopSnapWebApi.Models;

namespace ShopSnapWebApi.Controllers
{
    public interface IReceiptItemRepository
    {
        List<ReceiptItem> GetReceiptItemsByUserID(int userID);
    }
}