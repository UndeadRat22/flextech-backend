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
            List<FoundItem> found = null;
            //using (StreamWriter writer = new StreamWriter("log.txt"))
            //{
                //writer.WriteLine("Started Parsing");

                var resp = await _service.GetStringFromImage(base64image);
                found = _parseService.GetItemList(resp);
            //writer.WriteLine(found);
            //}
            return found;
        }
    }
}
