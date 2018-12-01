using ShopSnapWebApi.Models;
using ShopSnapWebApi.Services;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;

namespace ShopSnapWebApi.Controllers
{
    public class ValuesController : ApiController
    {
        private ReceiptOcrApiService _service = new ReceiptOcrApiService();
        private ReceiptParseService _parseService = new ReceiptParseService();

        // POST api/values
        public async Task<string[]> Post([FromBody]string base64image)
        {
            var resp = await _service.GetStringFromImage(base64image);

            return _parseService.GetReceiptItems(resp);
        }
    }
}
