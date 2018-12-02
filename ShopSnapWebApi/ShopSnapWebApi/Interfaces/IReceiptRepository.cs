using System.Collections.Generic;
using ShopSnapWebApi.Models;
using ShopSnapWebApi.Repositories;

namespace ShopSnapWebApi.Controllers
{
    public interface IReceiptRepository
    {
        List<Receipt> GetReceipts();
        List<Receipt> GetReceiptsByUserID(int userID);
       // void CreateReceipt(Receipt receipt);
        void CreateReceipt(ReceiptWithFoundItems receipt);
    }
}