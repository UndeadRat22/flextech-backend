using ShopSnapWebApi.Models;
using System.Collections.Generic;

namespace ShopSnapWebApi.Services.Abstract
{
    public interface IReceiptService
    {
        List<FoundItem> GetItemList(OcrResponse rawResponse);
    }
}