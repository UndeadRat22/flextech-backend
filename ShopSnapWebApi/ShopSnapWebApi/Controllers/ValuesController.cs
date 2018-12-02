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

        public async Task<List<FoundItem>> Post([FromBody]string base64image)
        {
            File.WriteAllText("log.txt", base64image);
            List<FoundItem> found = null;
            var resp = await _service.GetStringFromImage(base64image);
            found = _parseService.GetItemList(resp);
            return found;
        }
        
        public string Get()
        {
            return File.ReadAllText("log.txt");
        }
    }
}
