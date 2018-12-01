using ShopSnapWebApi.Controllers;
using ShopSnapWebApi.Interfaces;
using ShopSnapWebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShopSnapWebApi.Repositories
{
    public class UserSpendingsRepository : IUserSpendingsRepository
    {

        public decimal GetUserAllSpendings(int userID)
        {
            decimal allSpendings = 0;
            using (var db = new ShopSnapDatabaseContext())
            {
                var userReceipts = db.Receipts.Include("ReceiptItems").Where(r => r.UserID == userID).ToList();

                var returnItemList = new List<ReceiptItem>();

                foreach (var receipt in userReceipts)
                {
                    var receiptItemList = receipt.ReceiptItems.ToList();

                    foreach (var item in receiptItemList)
                    {
                        allSpendings += (decimal)item.Quantity * (decimal)item.Price;
                    }
                }

                return allSpendings;
            }
        }


    }
}