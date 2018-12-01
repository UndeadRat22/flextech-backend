using ShopSnap.Models;
using ShopSnap.Services;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace ShopSnap.Controllers
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
