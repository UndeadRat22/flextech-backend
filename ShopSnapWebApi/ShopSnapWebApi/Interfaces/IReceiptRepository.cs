using System.Collections.Generic;
using ShopSnapWebApi.Models;

namespace ShopSnapWebApi.Controllers
{
    public interface IReceiptRepository
    {
        List<Receipt> GetReceipts();
        List<Receipt> GetReceiptsByUserID(int userID);
        void CreateReceipt(Receipt receipt);
    }
}