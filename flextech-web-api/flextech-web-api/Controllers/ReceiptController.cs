using shopsnap.Models;
using ShopSnapWebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace shopsnap.Controllers
{
    public class ReceiptController : ApiController
    {
        public List<ReceiptWithItems> GetUserReceiptHistory(int userID)
        {
            List<ReceiptWithItems> userReceiptHistory = new List<ReceiptWithItems>();
            using (var db = new ShopSnapDatabaseContext())
            {
                var AllUserReceipts = db.Receipts.Where(r => r.UserID == userID).ToList();

                foreach (var receipt in AllUserReceipts)
                {
                    var userReceiptWithItems = new ReceiptWithItems();
                    userReceiptWithItems.UserReceipt = receipt;
                    userReceiptWithItems.UserReceiptItems = db.ReceiptItems.Where(i => i.ReceiptID == receipt.ID).ToList();
                    userReceiptHistory.Add(userReceiptWithItems);
                }

            }
            return userReceiptHistory;
        }

        //public List<ReceiptItem> GetReceipts()
        //{
        //    using (FlextechDatabaseContext db = new FlextechDatabaseContext())
        //    {
        //        db.Configuration.LazyLoadingEnabled = false;
        //        var rec = db.Receipts.Include(x => x.ReceiptItems);
        //    }
        //}
    }
}
