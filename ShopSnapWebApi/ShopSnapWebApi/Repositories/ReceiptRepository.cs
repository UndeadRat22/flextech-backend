using ShopSnapWebApi.Controllers;
using ShopSnapWebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShopSnapWebApi.Repositories
{
    public class ReceiptRepository : IReceiptRepository
    {
        public List<Receipt> GetReceipts()
        {
            using (var db = new ShopSnapDatabaseContext())
            {
                return db.Receipts.Include("ReceiptItems").ToList();
            }
        }

        public List<Receipt> GetReceiptsByUserID(int userID)
        {
            using (var db = new ShopSnapDatabaseContext())
            {
                return db.Receipts.Include("ReceiptItems").Where(r => r.UserID == userID).ToList();
            }
        }
    }
}