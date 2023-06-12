using _1_AppData._1_DataProcessing.Context;
using _1_AppData._1_DataProcessing.Models;
using _2_AppApi.ViewModels.Food;
using _3_AppView.Call;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace _3_AppView.Controllers
{
    public class FoodController : Controller
    {
        //public readonly DBContext_Assgiment _context;
        //public readonly IApiCallFood _IApiCallFood;

        Uri Url = new Uri("https://localhost:7075/api/food");
        HttpClient _httpClient;
        public FoodController()
        {
            //_context = new DBContext_Assgiment();
            //_IApiCallFood = apiCallFood;
            _httpClient = new HttpClient();
        }
        public async Task<IActionResult> ShowAllFood()
        {
            var response = await _httpClient.GetAsync(Url + "/get");// Lấy dữ liệu ra
                                                                    // Lấy dữ liệu Json trả về từ Api được call dạng string
            string apiData = await response.Content.ReadAsStringAsync();
            // Lấy kqua trả về từ API
            // Đọc từ string Json vừa thu được sang List<T>
            var fo = JsonConvert.DeserializeObject<List<Food>>(apiData);
            return View(fo);

        }
        public async Task<IActionResult> Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(CreateFood createFood, IFormFile imageFile)
        {
            try
            {



                if (imageFile != null && imageFile.Length > 0)//không null và không trống
                {
                    //trỏ tới thư mục để lát nữa thực hiện việc copy sang
                    var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images", imageFile.FileName);
                    using (var stream = new FileStream(path, FileMode.Create))
                    {
                        ///thực hiện copy hình ảnh vừa chọn sang thư mục mới(wwwroot)
                        imageFile.CopyTo(stream);
                    }
                    //gán lại giá trị cho descri của đối tượng bằng tên file ảnh đã được sao chép
                    createFood.Images = imageFile.FileName;
                }
                var response = await _httpClient.PostAsJsonAsync(Url, createFood);
                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction("ShowAllFood");
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
                var Role = JsonConvert.DeserializeObject<Food>(apiData);
                return View(Role);
            }
            else
            {
                var errorMessage = await response.Content.ReadAsStringAsync();
                ViewBag.ErrorMessage = errorMessage;
                return View();
            }
        }

        public async Task<IActionResult> Edit(Guid id, CreateFood createFood, IFormFile imageFile)
        {
            try
            {


                if (imageFile != null && imageFile.Length > 0)//không null và không trống
                {
                    //trỏ tới thư mục để lát nữa thực hiện việc copy sang
                    var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images", imageFile.FileName);
                    using (var stream = new FileStream(path, FileMode.Create))
                    {
                        ///thực hiện copy hình ảnh vừa chọn sang thư mục mới(wwwroot)
                        imageFile.CopyTo(stream);
                    }
                    //gán lại giá trị cho descri của đối tượng bằng tên file ảnh đã được sao chép
                    createFood.Images = imageFile.FileName;
                }
                var response = await _httpClient.PutAsJsonAsync(Url + $"/get-{id}", createFood);
                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction("ShowAllFood");
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
                var fo = JsonConvert.DeserializeObject<Food>(apiData);
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
                return RedirectToAction("ShowAllFood");
            }
            else
            {
                return BadRequest();
            }
        }
    }
}
