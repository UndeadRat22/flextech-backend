using ShopSnapWebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ShopSnapWebApi.Controllers
{
    public class StoreController : ApiController
    {

        public List<ReceiptItem> GetReceiptItemsByStoreID(int storeID)
        {
            using (var db = new ShopSnapDatabaseContext())
            {
                var userReceipts = db.Receipts.Include("ReceiptItems").Where(r => r.StoreID == storeID).ToList();

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
