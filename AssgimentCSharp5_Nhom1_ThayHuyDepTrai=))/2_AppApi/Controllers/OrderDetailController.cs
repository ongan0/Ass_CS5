using _2_AppApi._1_Treatment.IServices;
using _2_AppApi._1_Treatment.Services;
using _2_AppApi.ViewModels.OrderDetail;
using _2_AppApi.ViewModels.User;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace _2_AppApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderDetailController : ControllerBase
    {
        IOrderDetailServices _IOrderDetailServices;
        public OrderDetailController()
        {
            _IOrderDetailServices = new OrderDetailService();
        }
        // GET: api/<OrderDetailController>
        [HttpGet]
        public async Task<ActionResult> Get()
        {
            var user = await _IOrderDetailServices.GetOrderDetailAsync();
            return Ok(user);
        }

        // GET api/<OrderDetailController>/5
        [HttpGet("{ID}")]
        public async Task<ActionResult> Get(Guid ID)
        {
            try
            {
                var user = await _IOrderDetailServices.GetByIdAsync(ID);
                return Ok(user);
            }
            catch (Exception)
            {
                return Ok("Rồi! Mày xong rồi");
            }

        }

        // POST api/<OrderDetailController>
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] CreateOrderDetail obj)
        {
            try
            {
                int a = await _IOrderDetailServices.AddAsync(obj);
                if (a == 1)
                {
                    return Ok("Thêm thành công");
                }
                if (a == 2)
                {
                    return Ok("sai cái gì đó :>");
                }
                return Ok("");
            }
            catch (Exception)
            {
                return Ok("Rồi! Mày xong rồi");
            }

        }


        // PUT api/<OrderDetailController>/5
        [HttpPut("{ID}")]
        public async Task<ActionResult> Put(Guid ID, [FromBody] CreateOrderDetail obj)
        {
            var role = await _IOrderDetailServices.UpdateAsync(ID, obj);
            if (role == 1)
            {
                return Ok("Tao đúng rồi nè :)");
            }
            return Ok(role);
        }

        // DELETE api/<OrderDetailController>/5
        [HttpDelete("{ID}")]
        public async Task<ActionResult> Delete(Guid ID)
        {
            var user = await _IOrderDetailServices.RemoveAsync(ID);
            return Ok("okok");
        }
    }
}
