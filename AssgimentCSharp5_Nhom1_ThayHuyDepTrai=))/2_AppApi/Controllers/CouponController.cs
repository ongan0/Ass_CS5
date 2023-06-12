using _2_AppApi._1_Treatment.IServices;
using _2_AppApi._1_Treatment.Services;
using _2_AppApi.ViewModels.Coupons;
using _2_AppApi.ViewModels.Reviews;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace _2_AppApi.Controllers
{
    [Route("api/coupon")]
    [ApiController]
    public class CouponController : ControllerBase
    {
        private readonly ICouponsServices _couponsServices;
        public CouponController()
        {
            _couponsServices = new CouponsServices();
        }
        // GET: api/<CouponController>
        [HttpGet("get")]
        public async Task<ActionResult> Get()
        {
            var cou = await _couponsServices.GetCouponsAsync();
            return Ok(cou);
        }

        // GET api/<CouponController>/5
        [HttpGet("get-{ID}")]
        public async Task<ActionResult> Get(Guid ID)
        {
            var cou = await _couponsServices.GetByIdAsync(ID);
            return Ok(cou);
        }

        // POST api/<CouponController>
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] CreateCoupons obj)
        {
            var cou = await _couponsServices.AddAsync(obj);
            if (cou == 1)
            {
                return Ok("đã thêm thành công");
            }

            return Ok("Lỗi hệ thống");
        }

        // PUT api/<CouponController>/5
        [HttpPut("get-{ID}")]
        public async Task<ActionResult> Put(Guid ID, [FromBody] CreateCoupons obj)
        {
            var cou = await _couponsServices.UpdateAsync(ID, obj);
            if (cou == 1)
            {
                return Ok("đã sửa thành công");
            }

            return Ok("Lỗi hệ thống");
        }

        // DELETE api/<CouponController>/5
        [HttpDelete("get-{ID}")]
        public async Task<ActionResult> Delete(Guid ID)
        {
            var cou = await _couponsServices.RemoveAsync(ID);
            if (cou == 1)
            {
                return Ok("đã xoa thành công");
            }

            return Ok("Lỗi hệ thống");
        }
    }
}
