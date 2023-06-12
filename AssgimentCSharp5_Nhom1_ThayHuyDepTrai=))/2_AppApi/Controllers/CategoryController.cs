using _1_AppData._1_DataProcessing.Models;
using _2_AppApi._1_Treatment.IServices;
using _2_AppApi._1_Treatment.Services;
using _2_AppApi.ViewModels.Category;
using _2_AppApi.ViewModels.Role;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace _2_AppApi.Controllers
{
    [Route("api/category")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        IFoodServices _IFoodServices;
        ICategoryServices _ICategoryServices;
        public CategoryController()
        {
            _IFoodServices = new FoodServices();
            _ICategoryServices = new CategoryServices();
        }
        // GET: api/<CategoryController>
        [HttpGet("get")]
        public async Task<ActionResult> Get()
        {
            var Category = await _ICategoryServices.GetCategoryAsync();
            return Ok(Category);
        }

        // GET api/<CategoryController>/5
        [HttpGet("get-{ID}")]
        public async Task<ActionResult> Get(Guid ID)
        {
            var Category = await _ICategoryServices.GetByIdAsync(ID);
            return Ok(Category);
        }

        // POST api/<CategoryController>
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] CreateCategory obj)
        {
            await _ICategoryServices.AddAsync(obj);
            return Ok();
        }

        // PUT api/<CategoryController>/5
        [HttpPut("get-{ID}")]
        public async Task<ActionResult> Put(Guid ID, [FromBody] CreateCategory obj)
        {
            var Category = await _ICategoryServices.UpdateAsync(ID, obj);
            if (Category == 1)
            {
                return Ok("Tao đúng rồi nè :)");
            }
            return Ok(Category);
        }

        // DELETE api/<CategoryController>/5
        [HttpDelete("get-{ID}")]
        public async Task<ActionResult> Delete(Guid ID)
        {
            var Category = _ICategoryServices.RemoveAsync(ID);
            return Ok("");
        }
    }
}
