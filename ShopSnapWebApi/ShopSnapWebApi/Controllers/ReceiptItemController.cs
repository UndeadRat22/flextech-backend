using ShopSnapWebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ShopSnapWebApi.Repositories;

namespace ShopSnapWebApi.Controllers
{
    public class ReceiptItemController : ApiController
    {
        IReceiptItemRepository _receiptItemRepository;

        public ReceiptItemController(IReceiptItemRepository receiptItemRepository)
        {
            _receiptItemRepository = receiptItemRepository;
        }

        public List<ReceiptItem> GetReceiptItemsByUserID(int userID)
        {
            return _receiptItemRepository.GetReceiptItemsByUserID(userID);
        }
    }
}
