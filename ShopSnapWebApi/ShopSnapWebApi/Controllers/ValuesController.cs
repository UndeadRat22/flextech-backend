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
        private ReceiptServiceIki _parseService = new ReceiptServiceIki();

        // POST api/values
        public async Task<List<FoundItem>> Post([FromBody]string base64image)
        {
            var resp = await _service.GetStringFromImage(base64image);

            return _parseService.GetItemList(resp);
        }
    }
}
