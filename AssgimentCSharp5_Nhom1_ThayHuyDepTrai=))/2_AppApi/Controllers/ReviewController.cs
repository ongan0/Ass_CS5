using _2_AppApi._1_Treatment.IServices;
using _2_AppApi._1_Treatment.Services;
using _2_AppApi.ViewModels.Combo;
using _2_AppApi.ViewModels.Reviews;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace _2_AppApi.Controllers
{
    [Route("api/review")]
    [ApiController]
    public class ReviewController : ControllerBase
    {
        IReviewsServices _IReviewsServices;
        public ReviewController()
        {
            _IReviewsServices = new ReviewsServices();
        }
        // GET: api/<ReviewController>
        [HttpGet("get")]
        public async Task<ActionResult> Get()
        {
            var re = await _IReviewsServices.GetReviewsAsync();
            return Ok(re);
        }

        // GET api/<ReviewController>/5
        [HttpGet("get-{ID}")]
        public async Task<ActionResult> Get(Guid ID)
        {
            var revi = await _IReviewsServices.GetByIdAsync(ID);
            return Ok(revi);
        }

        // POST api/<ReviewController>
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] CreateReviews obj)
        {
            var result = await _IReviewsServices.AddAsync(obj);
            if (result == 1)
            {
                return Ok("đã thêm thành công");
            }

            return Ok("Lỗi hệ thống");
        }

        // PUT api/<ReviewController>/5
        [HttpPut("get-{ID}")]
        public async Task<ActionResult> Put(Guid ID, [FromBody] CreateReviews obj)
        {
            var revi = await _IReviewsServices.UpdateAsync(ID, obj);
            if (revi == 1)
            {
                return Ok("đã sửa thành công");
            }

            return Ok("Lỗi hệ thống");
        }

        // DELETE api/<ReviewController>/5
        [HttpDelete("get-{ID}")]
        public async Task<ActionResult> Delete(Guid ID)
        {
            var revi = await _IReviewsServices.RemoveAsync(ID);
            if (revi == 1)
            {
                return Ok("đã xoa thành công");
            }

            return Ok("Lỗi hệ thống");
        }
    }
}
