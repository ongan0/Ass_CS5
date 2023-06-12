using _1_AppData._1_DataProcessing.Models;
using _2_AppApi.ViewModels.Category;
using _2_AppApi.ViewModels.Food;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace _3_AppView.Controllers
{
    public class CategoryController : Controller
    {
        Uri Url = new Uri("https://localhost:7075/api/category");
        HttpClient _httpClient;
        public CategoryController()
        {
            //_context = new DBContext_Assgiment();
            //_IApiCallFood = apiCallFood;
            _httpClient = new HttpClient();
        }
        public async Task<IActionResult> ShowAllCategory()
        {
            var response = await _httpClient.GetAsync(Url + "/get");// Lấy dữ liệu ra
                                                                    // Lấy dữ liệu Json trả về từ Api được call dạng string
            string apiData = await response.Content.ReadAsStringAsync();
            // Lấy kqua trả về từ API
            // Đọc từ string Json vừa thu được sang List<T>
            var ct = JsonConvert.DeserializeObject<List<Category>>(apiData);
            return View(ct);

        }
        public async Task<IActionResult> Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(CreateCategory createCategory)
        {
            try
            {
                var response = await _httpClient.PostAsJsonAsync(Url, createCategory);
                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction("ShowAllCategory");
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
                var Role = JsonConvert.DeserializeObject<Category>(apiData);
                return View(Role);
            }
            else
            {
                var errorMessage = await response.Content.ReadAsStringAsync();
                ViewBag.ErrorMessage = errorMessage;
                return View();
            }
        }

        public async Task<IActionResult> Edit(Guid id, CreateCategory create)
        {
            try
            {

                var response = await _httpClient.PutAsJsonAsync(Url + $"/get-{id}", create);
                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction("ShowAllCategory");
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
        public async Task<IActionResult> Details(Guid Id)
        {
            var response = await _httpClient.GetAsync(Url + $"/get-{Id}");

            if (response.IsSuccessStatusCode)
            {
                var apiData = await response.Content.ReadAsStringAsync();
                var fo = JsonConvert.DeserializeObject<Category>(apiData);
                return View(fo);
            }
            else
            {
                var errorMessage = await response.Content.ReadAsStringAsync();
                ViewBag.ErrorMessage = errorMessage;
                return View();
            }
        }
        [HttpGet]
        public async Task<IActionResult> Remove(Guid Id)
        {
            var response = await _httpClient.DeleteAsync(Url + $"/get-{Id}");

            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("ShowAllCategory");
            }
            else
            {
                return BadRequest();
            }
        }
    }
}
