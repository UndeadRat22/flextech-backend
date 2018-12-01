using ShopSnapWebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Data.Entity;


namespace ShopSnapWebApi.Controllers
{
    public class ReceiptController : ApiController
    {
        public List<Receipt> GetReceipts()
        {
            using (var db = new ShopSnapCodeFirstDataModel())
            {
                return db.Receipts.Include("ReceiptItems").ToList();
            }
        }
    }
}
