using _2_AppApi._1_Treatment.IServices;
using _2_AppApi._1_Treatment.Services;
using _2_AppApi.ViewModels.Ordel;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace _2_AppApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        IOrdelServices _IOrdelServices;
        public OrderController()
        {
            _IOrdelServices = new OrderServices();
        }
        // GET: api/<OrderController>
        [HttpGet]
        public async Task<ActionResult> Get()
        {
            var order = await _IOrdelServices.GetOrdelAsync();
            return Ok(order);
        }

        // GET api/<OrderController>/5
        [HttpGet("{ID}")]
        public async Task<ActionResult> Get(Guid ID)
        {
            var order = await _IOrdelServices.GetByIdAsync(ID);
            return Ok(order);
        }

        // POST api/<OrderController>
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] CreateOrdel obj)
        {
            int order = await _IOrdelServices.AddAsync(obj);
            if (order == 1)
            {
                return Ok("Thêm thành công");
            }
            return Ok();
        }

        // PUT api/<OrderController>/5
        [HttpPut("{ID}")]
        public void Put(Guid ID, [FromBody] CreateOrdel obj)
        {

        }

        // DELETE api/<OrderController>/5
        [HttpDelete("{ID}")]
        public async Task<ActionResult> Delete(Guid ID)
        {
            var order = await _IOrdelServices.RemoveAsync(ID);
            return Ok("okok");
        }
    }
}
