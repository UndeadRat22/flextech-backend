using ShopSnapWebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ShopSnapWebApi.Controllers
{
    public class ReceiptItemController : ApiController
    {

        public List<ReceiptItem> GetReceiptItemsByUserID(int userID)
        {
            using (var db = new ShopSnapDatabaseContext())
            {
                var userReceipts = db.Receipts.Include("ReceiptItems").Where(r => r.UserID == userID).ToList();

                var returnItemList = new List<ReceiptItem>();

                foreach (var receipt in userReceipts)
                {
                    var receiptItemList = receipt.ReceiptItems.ToList();

                    foreach (var item in receiptItemList)
                    {
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

                return returnItemList;
            }
        }
    }
}
