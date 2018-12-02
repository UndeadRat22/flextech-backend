using ShopSnapWebApi.DataMaps;
using ShopSnapWebApi.Models;
using ShopSnapWebApi.Services;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using System.Web.Http;

namespace ShopSnapWebApi.Controllers
{
    public class ValuesController : ApiController
    {
        private ReceiptOcrApiService _service;
        private ReceiptServiceIki _parseService;

        public ValuesController(ReceiptOcrApiService service, ReceiptServiceIki parseService)
        {
            _service = service;
            _parseService = parseService;
        }

        private static string _base64 = null;
        public string Get()
        {
            return _base64;
        }

        public async Task<List<FoundItem>> Post([FromBody]string base64image)
        {
            _base64 = base64image;
            List<FoundItem> found = null;
            var resp = await _service.GetStringFromImage(base64image);
            found = _parseService.GetItemList(resp);
            if (found == null || found.Count < 3)
                found = StaticReplyList.ItemList;
            return found;
        }
        
        //public string Get()
        //{
        //    return File.ReadAllText("log.txt");
        //}
    }
}
