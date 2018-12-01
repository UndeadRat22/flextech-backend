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
        public IReceiptRepository _receiptRepsitory;

        public ReceiptController(IReceiptRepository receiptRepsitory)
        {
            _receiptRepsitory = receiptRepsitory;
        }

        public List<Receipt> GetReceipts()
        {
            return _receiptRepsitory.GetReceipts();
        }

        public List<Receipt> GetReceiptsByUserID(int userID)
        {
            return _receiptRepsitory.GetReceiptsByUserID(userID);
        }

    }
}
