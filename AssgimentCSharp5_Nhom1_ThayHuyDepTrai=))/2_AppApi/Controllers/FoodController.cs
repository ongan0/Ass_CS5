using _2_AppApi._1_Treatment.IServices;
using _2_AppApi._1_Treatment.Services;
using _2_AppApi.ViewModels.Food;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace _2_AppApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FoodController : ControllerBase
    {
        IFoodServices _IFoodServices;
        public FoodController(/*IRoleServices roleServices*/)
        {
            _IFoodServices = new FoodServices();
        }
        [HttpGet]
        public async Task<ActionResult> Get()
        {
            var roles = await _IFoodServices.GetRoleAsync();
            return Ok(roles);
        }
        // GET api/<RoleController>/5
        [HttpGet("{ID}")]
        public async Task<ActionResult> Get(Guid ID)
        {
            var role = await _IFoodServices.GetByIdAsync(ID);
            return Ok(role);
        }

        // POST api/<RoleController>
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] CreateFood obj)
        {
            var result = await _IFoodServices.AddAsync(obj);
            if (result == 1)
            {
                return Ok("đã thêm thành công");
            }

            return Ok("Lỗi hệ thống");
        }

        // PUT api/<RoleController>/5
        [HttpPut("{ID}")]
        public async Task<ActionResult> Put(Guid ID, [FromBody] CreateFood obj)
        {
            var result = await _IFoodServices.UpdateAsync(ID, obj);
            if (result == 1)
            {
                return Ok("đã sửa thành công");
            }
            if (result == 2)
            {
                return Ok("không tìm thấy Food này");
            }
            return Ok("Lỗi hệ thống");
        }

        // DELETE api/<RoleController>/5
        [HttpDelete("{ID}")]
        public async Task<ActionResult> Delete(Guid ID)
        {
            var result = await _IFoodServices.RemoveAsync(ID);
            if (result == 1)
            {
                return Ok("Tao xóa thành công");
            }
            if (result == 2)
            {
                return Ok("không tìm thấy Food này");
            }
            return Ok("Lỗi hệ thống");
        }
    }
}
