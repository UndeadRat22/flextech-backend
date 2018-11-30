using flextech_web_api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace flextech_web_api.Controllers
{
    public class PurchaseController : ApiController
    {
        public List<Purchase> GetPurchases()
        {
            using(var db = new FlextechDatabaseContext())
            {
                return db.Purchases.ToList();
            }
        }
    }
}
