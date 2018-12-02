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
                var list = db.Receipts.Include("ReceiptItems").Include("Store").ToList();
                return list;
            }
        }

        public List<Receipt> GetReceiptsByUserID(int userID)
        {
            using (var db = new ShopSnapDatabaseContext())
            {
                return db.Receipts.Include("ReceiptItems").Include("Store").Where(r => r.UserID == userID).ToList();
            }
        }

        //public void CreateReceipt(Receipt receipt)
        //{
        //    using(var db = new ShopSnapDatabaseContext())
        //    {
        //        db.Receipts.Add(receipt);
        //        db.SaveChanges();
        //    }
        //}

        public void CreateReceipt(ReceiptWithFoundItems receiptWithFoundItems)
        {

            var receipt = new Receipt
            {
                ID = receiptWithFoundItems.ID,
                StoreID = receiptWithFoundItems.StoreID,
                Date = receiptWithFoundItems.Date,
                UserID = receiptWithFoundItems.UserID
            };

            var receiptItemList = new List<ReceiptItem>();

            foreach(var foundItem in receiptWithFoundItems.ReceiptFoundItems)
            {
                var receiptItem = new ReceiptItem
                {
                    Name = foundItem.Name,
                    Quantity = foundItem.Amount,

                };
                
            }

            using(var db = new ShopSnapDatabaseContext())
            {
                db.Receipts.Add(receipt);
                db.SaveChanges();
            }
        }
    }
}