using System.Diagnostics;
using System.Threading.Tasks;
using ShopSnap.Models;
using Newtonsoft.Json;
using RestSharp;

namespace ShopSnap.Services
{
    public class ReceiptOcrApiService
    {
        private string _ocrApiKey = "1d9211ee2788957";
        private string _apiURL = @"https://api.ocr.space/Parse/";

        public async Task<OcrResponse> GetStringFromImage(string base64)
        {
            IRestResponse<string> resp = await GetOcrResponseAsync(base64);
            if (resp.StatusCode == System.Net.HttpStatusCode.OK)
            {
                Debug.WriteLine(resp.Content);
                OcrResponse ocrResult = JsonConvert.DeserializeObject<OcrResponse>(resp.Content);
                return ocrResult;
            }
            return new OcrResponse();
        }

        private async Task<IRestResponse<string>> GetOcrResponseAsync(string base64)
        {
            RestClient client = new RestClient(_apiURL);
            RestRequest request = new RestRequest("Image", Method.POST)
            {
                RequestFormat = DataFormat.Json
            };
            request.AddParameter("apikey", _ocrApiKey);
            request.AddParameter("base64Image", "data:image/jpg;base64," + base64);
            request.AddParameter("filetype", "JPG");

            Task<IRestResponse<string>> resp = client.ExecuteTaskAsync<string>(request);
            return await resp;
        }
    }
}