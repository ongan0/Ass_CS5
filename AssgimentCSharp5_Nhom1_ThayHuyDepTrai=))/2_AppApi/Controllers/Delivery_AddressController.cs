using _2_AppApi._1_Treatment.IServices;
using _2_AppApi._1_Treatment.Services;
using _2_AppApi.ViewModels.Category;
using _2_AppApi.ViewModels.Delivery_Address;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace _2_AppApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Delivery_AddressController : ControllerBase
    {
        IDelivery_AddressServices _IDelivery_Address;
        public Delivery_AddressController()
        {
            _IDelivery_Address =new Delivery_AddressServices();
        }
        // GET: api/<Delivery_AddressController>
        [HttpGet]
        public async Task<ActionResult> Get()
        {
            var data = await _IDelivery_Address.GetDelivery_AddressAsync();
            return Ok(data);
        }

        // GET api/<Delivery_AddressController>/5
        [HttpGet("{ID}")]
        public async Task<ActionResult> Get(Guid ID)
        {
            var data = await _IDelivery_Address.GetByIdAsync(ID);
            return Ok(data);
        }

        // POST api/<Delivery_AddressController>
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] CreateDelivery_Address Obj)
        {
            await _IDelivery_Address.AddAsync(Obj);
            return Ok();
        }

        // PUT api/<Delivery_AddressController>/5
        [HttpPut("{ID}")]
        public async Task<ActionResult> Put(Guid ID, [FromBody] CreateDelivery_Address obj)
        {
            var Delivery_Address = await _IDelivery_Address.UpdateAsync(ID, obj);
            if (Delivery_Address == 1)
            {
                return Ok("Tao đúng rồi nè :)");
            }
            return Ok(Delivery_Address);
        }

        // DELETE api/<Delivery_AddressController>/5
        [HttpDelete("{ID}")]
        public async Task<ActionResult> Delete(Guid ID)
        {
            await _IDelivery_Address.RemoveAsync(ID);
            return Ok();
        }
    }
}
