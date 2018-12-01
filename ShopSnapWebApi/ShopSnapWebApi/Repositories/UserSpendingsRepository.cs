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

        public decimal GetUserMonthSpendings(int userID)
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
                        //allSpendings += item.Quantity;
                        returnItemList.Add(
                            new ReceiptItem()
                            {
                                ID = item.ID,
                                Name = item.Name,
                                Price = item.Price,
                                Quantity = item.Quantity,
                                ReceiptID = item.ReceiptID
                            });
                        

                    }
                }

                return allSpendings;
            }
        }


    }
}