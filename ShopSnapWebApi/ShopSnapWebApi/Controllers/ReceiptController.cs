using ShopSnapWebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Data.Entity;
using ShopSnapWebApi.Repositories;

namespace ShopSnapWebApi.Controllers
{
    public class ReceiptController : ApiController
    {
        public IReceiptRepository _receiptRepository;

        public ReceiptController(IReceiptRepository receiptRepsitory)
        {
            _receiptRepository = receiptRepsitory;
        }

        public List<Receipt> GetReceipts()
        {
            return _receiptRepository.GetReceipts();
        }

        public List<Receipt> GetReceiptsByUserID(int userID)
        {
            return _receiptRepository.GetReceiptsByUserID(userID);
        }

        [HttpPost]
        [ActionName("Create")]
        public void CreateReceipt([FromBody]ReceiptWithFoundItems receipt)
        {
            _receiptRepository.CreateReceipt(receipt);
        }
    }
}
