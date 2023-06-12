using _1_AppData._1_DataProcessing.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace _3_AppView.Controllers
{
    public class BillDetailController : Controller
    {
        readonly HttpClient _httpClient;

        public BillDetailController(HttpClient httpClient) {
            _httpClient = httpClient;
        }

        public async Task<IActionResult> Index(Guid id)
        {

            var apiUrl = $"https://localhost:7075/api/billdetail/get-{id}";
            var request = new HttpRequestMessage(HttpMethod.Get, apiUrl);
            var response = await _httpClient.SendAsync(request);
            if (response.IsSuccessStatusCode)
            {
                var listBillDetails = JsonConvert.DeserializeObject<List<BillDetail>>(await response.Content.ReadAsStringAsync());
                return View(listBillDetails);
            }
            return View();
        }
    }
}
