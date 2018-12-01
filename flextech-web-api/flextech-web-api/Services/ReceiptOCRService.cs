using System.Threading.Tasks;
using flextech_web_api.Models;
using RestSharp;

namespace flextech_web_api.Services
{
    public class ReceiptOCRService
    {
        private string _ocrApiKey = "1d9211ee2788957";
        private string _apiURL = @"https://api.ocr.space/Parse/";

        public async Task<string> GetStringFromImage(string base64)
        {
            IRestResponse<OcrResponse> resp = await GetOcrResponseAsync(base64);
            return resp.Content;
        }

        private async Task<IRestResponse<OcrResponse>> GetOcrResponseAsync(string base64)
        {
            RestClient client = new RestClient(_apiURL);
            RestRequest request = new RestRequest("Image", Method.POST)
            {
                RequestFormat = DataFormat.Json
            };
            request.AddParameter("apikey", _ocrApiKey);
            request.AddParameter("base64Image", "data:image/jpg;base64," + base64);
            request.AddParameter("filetype", "JPG");

            Task<IRestResponse<OcrResponse>> resp = client.ExecuteTaskAsync<OcrResponse>(request);
            return await resp;
        }
    }
}