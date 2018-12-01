using flextech_web_api.Models;
using flextech_web_api.Services;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace flextech_web_api.Controllers
{
    public class ValuesController : ApiController
    {
        private ReceiptOcrService _service = new ReceiptOcrService();

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
