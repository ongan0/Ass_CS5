using _1_AppData._1_DataProcessing.Models;
using _2_AppApi.ViewModels.Bill;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using static NuGet.Packaging.PackagingConstants;

namespace _3_AppView.Controllers
{
    public class BillController : Controller
    {
        private readonly HttpClient _httpClient;

        public BillController(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<IActionResult> Index()
        {

            var listBill = new List<Bill>();
            var apiUrl = "https://localhost:7075/api/bill/get";
            var request = new HttpRequestMessage(HttpMethod.Get, apiUrl);
            var response = await _httpClient.SendAsync(request);
            if (response.IsSuccessStatusCode)
            {
                var apiUrlUser = "https://localhost:7075/api/user/get";
                var requestUser = new HttpRequestMessage(HttpMethod.Get, apiUrlUser);
                var responseUser = await _httpClient.SendAsync(requestUser);
                var responseBodyUser = await responseUser.Content.ReadAsStringAsync();
                //ViewData["ListUser"] = JsonConvert.DeserializeObject<List<Bill>>(responseBodyUser);
                var listUser = JsonConvert.DeserializeObject<List<User>>(responseBodyUser);
                var responseBody = await response.Content.ReadAsStringAsync();
                listBill = JsonConvert.DeserializeObject<List<Bill>>(responseBody);
                // tạo view bill
                List<BillShow> result = (from bill in listBill
                             join user in listUser on bill.UserID equals user.ID
                             select new BillShow{
                                ID = bill.UserID,
                                UserID = user.ID,
                                UserName = user.Name,
                                Actual_Delivery_Date = bill.Actual_Delivery_Date,
                                Delivery_Date = bill.Delivery_Date,
                                Delivery_Status = bill.Delivery_Status,
                                OrderDate = bill.OrderDate,
                                Payment_Status = bill.Payment_Status,
                                Shipping_Address = bill.Shipping_Address,
                                Shipping_Cost = bill.Shipping_Cost,
                                TotalPrice = bill.TotalPrice
                            }).ToList();
                return View(result);
            }
            return View();

        }
    }
}
