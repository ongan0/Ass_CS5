using _1_AppData._1_DataProcessing.Models;
using _2_AppApi.ViewModels.Combo;
using _2_AppApi.ViewModels.Coupons;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace _3_AppView.Controllers
{
    public class CouponController : Controller
    {
        Uri Url = new Uri("https://localhost:7075/api/coupon");
        HttpClient _httpClient;
        public CouponController()
        {
            _httpClient = new HttpClient();
        }

        public async Task<IActionResult> ShowAllCoupon()
        {
            var response = await _httpClient.GetAsync(Url + "/get");// Lấy dữ liệu ra
                                                                    // Lấy dữ liệu Json trả về từ Api được call dạng string
            string apiData = await response.Content.ReadAsStringAsync();
            // Lấy kqua trả về từ API
            // Đọc từ string Json vừa thu được sang List<T>
            var c = JsonConvert.DeserializeObject<List<Coupons>>(apiData);
            return View(c);
        }


        [HttpGet]
        public async Task<IActionResult> Details(Guid id)
        {
            var response = await _httpClient.GetAsync(Url + $"/get-{id}");

            if (response.IsSuccessStatusCode)
            {
                var apiData = await response.Content.ReadAsStringAsync();
                var c = JsonConvert.DeserializeObject<Coupons>(apiData);
                return View(c);
            }
            else
            {
                var errorMessage = await response.Content.ReadAsStringAsync();
                ViewBag.ErrorMessage = errorMessage;
                return View();
            }
        }


        public async Task<IActionResult> Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(CreateCoupons create)
        {
            try
            {
                var response = await _httpClient.PostAsJsonAsync(Url, create);
                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction("ShowAllCoupon");
                }
                else
                {
                    var errorMessage = await response.Content.ReadAsStringAsync();
                    ViewBag.ErrorMessage = errorMessage;
                    return View();
                }

            }
            catch (Exception)
            {
                return View();
            }
        }


        [HttpGet]
        public async Task<IActionResult> Edit(Guid id)
        {
            var response = await _httpClient.GetAsync(Url + $"/get-{id}");
            if (response.IsSuccessStatusCode)
            {
                var apiData = await response.Content.ReadAsStringAsync();
                var Role = JsonConvert.DeserializeObject<Coupons>(apiData);
                return View(Role);
            }
            else
            {
                var errorMessage = await response.Content.ReadAsStringAsync();
                ViewBag.ErrorMessage = errorMessage;
                return View();
            }
        }

        public async Task<IActionResult> Edit(Guid id, CreateCoupons create)
        {
            try
            {

                var response = await _httpClient.PutAsJsonAsync(Url + $"/get-{id}", create);
                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction("ShowAllCoupon");
                }
                else
                {
                    var errorMessage = await response.Content.ReadAsStringAsync();
                    ViewBag.ErrorMessage = errorMessage;
                    return View();
                }

            }
            catch (Exception)
            {
                return View();
            }
        }


        [HttpGet]
        public async Task<IActionResult> Remove(Guid Id)
        {
            var response = await _httpClient.DeleteAsync(Url + $"/get-{Id}");

            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("ShowAllCoupon");
            }
            else
            {
                return BadRequest();
            }
        }
    }
}
