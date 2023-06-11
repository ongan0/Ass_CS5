using _1_AppData._1_DataProcessing.Context;
using _1_AppData._1_DataProcessing.Models;
using _3_AppView.Call;
using Microsoft.AspNetCore.Mvc;

namespace _3_AppView.Controllers
{
    public class FoodController : Controller
    {
        //public readonly DBContext_Assgiment _context;
        public readonly IApiCallFood _IApiCallFood;
        public FoodController(IApiCallFood apiCallFood)
        {
            //_context = new DBContext_Assgiment();
            _IApiCallFood = apiCallFood;
        }
        public async Task<ActionResult> Index()
        {
            try
            {
                List<Food> lst = new List<Food>();
                lst = await _IApiCallFood.GetByFood();
                return View(lst);
            }
            catch (Exception)
            {
                return View();
            }
        }
    }
}
