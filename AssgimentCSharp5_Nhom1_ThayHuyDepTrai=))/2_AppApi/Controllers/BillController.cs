using _2_AppApi._1_Treatment.IServices;
using _2_AppApi._1_Treatment.Services;
using _2_AppApi.ViewModels.Bill;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace _2_AppApi.Controllers
{
    [Route("api/bill")]
    [ApiController]
    public class BillController : ControllerBase
    {
        IBillServices _IBillServices;
        public BillController(/*IRoleServices roleServices*/)
        {
            _IBillServices = new BillServices();
        }
        [HttpGet("get")]
        public async Task<ActionResult> Get()
        {
            var roles = await _IBillServices.GetBillAsync();
            return Ok(roles);
        }
        // GET api/<RoleController>/5
        [HttpGet("get-{ID}")]
        public async Task<ActionResult> Get(Guid ID)
        {
            var role = await _IBillServices.GetByIdAsync(ID);
            return Ok(role);
        }

        // POST api/<RoleController>
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] CreateBill obj)
        {
            var result = await _IBillServices.AddAsync(obj);
            if (result == 1)
            {
                return Ok("đã thêm thành công");
            }
            if (result == 3)
            {
                return Ok("không tìm thấy User");
            }
            if (result == 4)
            {
                return Ok("không tìm thấy Delivery_Address");
            }

            return Ok("Lỗi hệ thống");
        }

        // PUT api/<RoleController>/5
        [HttpPut("{ID}")]
        public async Task<ActionResult> Put(Guid ID, [FromBody] CreateBill obj)
        {
            var result = await _IBillServices.UpdateAsync(ID, obj);
            if (result == 1)
            {
                return Ok("đã sửa thành công");
            }
            if (result == 2)
            {
                return Ok("không tìm thấy Bill này");
            }
            if (result == 3)
            {
                return Ok("không tìm thấy User");
            }
            if (result == 4)
            {
                return Ok("không tìm thấy Delivery_Address");
            }
            return Ok("Lỗi hệ thống");
        }

        // DELETE api/<RoleController>/5
        [HttpDelete("{ID}")]
        public async Task<ActionResult> Delete(Guid ID)
        {
            var result = await _IBillServices.RemoveAsync(ID);
            if (result == 1)
            {
                return Ok(" đã xóa thành công");
            }
            if (result == 2)
            {
                return Ok("không tìm thấy Bill này");
            }
            return Ok("Lỗi hệ thống");
        }
    }
}
