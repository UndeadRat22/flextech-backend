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

        // GET api/values
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        public string Get(int id)
        {
            return "balls";
        }

        // POST api/values
        public async Task<OcrResponse> Post([FromBody]string base64image)
        {
            var resp = await _service.GetStringFromImage(base64image);
            return resp;
        }
    }
}
