using Assignment_Chsarp5_datntph19899._2_Handle_Operation._1_IServices;
using Assignment_Chsarp5_datntph19899._2_Handle_Operation._3_ViewModels;
using Assignment_CS5_Share._1_Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Assignment_Chsarp5_datntph19899.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private ICategoryServices _icategoryServices;
        public CategoryController(ICategoryServices categoryServices)
        {
            _icategoryServices = categoryServices;
        }
        [HttpGet]
        public async Task<ActionResult<CategoryViewModels>> GetAllCategory()
        {
            var sp = await _icategoryServices.GetCategoryAsync();
            return Ok(sp);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Category>> GetCategory(Guid id)
        {
            var sp = await _icategoryServices.GetByIdAsync(id);
            return Ok(sp);
        }
        [HttpPost]
        public async Task<ActionResult<CategoryViewModels>> PostCategory(CategoryViewModels category)
        {
            var sp = await _icategoryServices.AddAsync(category);
            return Ok();
        }
        [HttpPut]
        public async Task<ActionResult<CategoryViewModels>> PutCategory(CategoryViewModels category)
        {
            var sp = await _icategoryServices.UpdateAsync(category);
            return Ok();
        }
        [HttpDelete]
        public async Task<ActionResult<CategoryViewModels>> DeleteCategory(Guid id)
        {
            var sp = await _icategoryServices.GetByIdAsync(id);
            if (sp == null)
            {
                return NotFound();
            }
            var ct = await _icategoryServices.RemoveAsync(id);
            return Ok();
        }
    }
}
