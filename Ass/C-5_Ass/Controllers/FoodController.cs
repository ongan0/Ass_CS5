using Assignment_Chsarp5_datntph19899._2_Handle_Operation._1_IServices;
using Assignment_Chsarp5_datntph19899._2_Handle_Operation._3_ViewModels;
using Assignment_CS5_Share._1_Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Assignment_Chsarp5_datntph19899.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FoodController : ControllerBase
    {
        private IFoodServices _ifoodServices;
        public FoodController(IFoodServices foodServices)
        {
            _ifoodServices = foodServices;
        }
        [HttpGet]
        public async Task<ActionResult<FoodViewModels>> GetAllFood()
        {
            var fo = await _ifoodServices.GetFoodsAsync();
            return Ok(fo);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Food>> GetFood(Guid id)
        {
            var fo = await _ifoodServices.GetFoodByIdAsync(id);
            return Ok(fo);
        }
        [HttpPost]
        public async Task<ActionResult<Food>> PostFood(FoodViewModels food)
        {
            var fo = await _ifoodServices.AddFoodAsync(food);
            return Ok();
        }
        [HttpPut]
        public async Task<ActionResult<FoodViewModels>> PutFood(FoodViewModels food)
        {
            var fo = await _ifoodServices.UpdateFoodAsync(food);
            return Ok();
        }
        [HttpDelete]
        public async Task<ActionResult<FoodViewModels>> DeleteFood(Guid id)
        {
            var fo = await _ifoodServices.GetFoodByIdAsync(id);
            if (fo == null)
            {
                return NotFound();
            }
            var fod = await _ifoodServices.DeleteFoodAsync(id);
            return Ok();
        }
    }
}
