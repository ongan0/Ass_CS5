using _1_AppData._1_DataProcessing.Models;
using _2_AppApi.ViewModels.Category;
using _2_AppApi.ViewModels.Combo;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace _3_AppView.Controllers
{
    public class ComboController : Controller
    {
        Uri Url = new Uri("https://localhost:7075/api/combo");
        HttpClient _httpClient;
        public ComboController()
        {
            //_context = new DBContext_Assgiment();
            //_IApiCallFood = apiCallFood;
            _httpClient = new HttpClient();
        }
        // GET: ComboController
        public async Task<IActionResult> ShowAllCombo()
        {
            var response = await _httpClient.GetAsync(Url + "/get");// Lấy dữ liệu ra
                                                                    // Lấy dữ liệu Json trả về từ Api được call dạng string
            string apiData = await response.Content.ReadAsStringAsync();
            // Lấy kqua trả về từ API
            // Đọc từ string Json vừa thu được sang List<T>
            var ct = JsonConvert.DeserializeObject<List<Combo>>(apiData);
            return View(ct);
        }

        // GET: ComboController/Details/5
        [HttpGet]
        public async Task<IActionResult> Details(Guid id)
        {
            var response = await _httpClient.GetAsync(Url + $"/get-{id}");

            if (response.IsSuccessStatusCode)
            {
                var apiData = await response.Content.ReadAsStringAsync();
                var fo = JsonConvert.DeserializeObject<Combo>(apiData);
                return View(fo);
            }
            else
            {
                var errorMessage = await response.Content.ReadAsStringAsync();
                ViewBag.ErrorMessage = errorMessage;
                return View();
            }
        }

        // GET: ComboController/Create
        public async Task<IActionResult> Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(CreateCombo create)
        {
            try
            {
                var response = await _httpClient.PostAsJsonAsync(Url, create);
                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction("ShowAllCombo");
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

        // GET: ComboController/Edit/5
        [HttpGet]
        public async Task<IActionResult> Edit(Guid id)
        {
            var response = await _httpClient.GetAsync(Url + $"/get-{id}");
            if (response.IsSuccessStatusCode)
            {
                var apiData = await response.Content.ReadAsStringAsync();
                var Role = JsonConvert.DeserializeObject<Combo>(apiData);
                return View(Role);
            }
            else
            {
                var errorMessage = await response.Content.ReadAsStringAsync();
                ViewBag.ErrorMessage = errorMessage;
                return View();
            }
        }

        public async Task<IActionResult> Edit(Guid id, CreateCombo create)
        {
            try
            {

                var response = await _httpClient.PutAsJsonAsync(Url + $"/get-{id}", create);
                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction("ShowAllCombo");
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
                return RedirectToAction("ShowAllCombo");
            }
            else
            {
                return BadRequest();
            }
        }
    }
}
