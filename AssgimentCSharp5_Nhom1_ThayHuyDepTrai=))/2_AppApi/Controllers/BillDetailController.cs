using _2_AppApi._1_Treatment.IServices;
using _2_AppApi._1_Treatment.Services;
using _2_AppApi.ViewModels.BillDetail;
using _2_AppApi.ViewModels.OrderDetail;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace _2_AppApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BillDetailController : ControllerBase
    {
        IBillDetailServices _IBillDetailServices;
        public BillDetailController()
        {
            _IBillDetailServices = new BillDetailServices();
        }
        // GET: api/<BillDetailController>
        [HttpGet]
        public async Task<ActionResult> Get()
        {
            var user = await _IBillDetailServices.GetBillDetailAsync();
            return Ok(user);
        }

        // GET api/<BillDetailController>/5
        [HttpGet("{ID}")]
        public async Task<ActionResult> Get(Guid ID)
        {
            try
            {
                var user = await _IBillDetailServices.GetByIdAsync(ID);
                return Ok(user);
            }
            catch (Exception)
            {
                return Ok("Rồi! Mày xong rồi");
            }

        }

        // POST api/<BillDetailController>
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] CreateBillDetail obj)
        {
            try
            {
                int a = await _IBillDetailServices.AddAsync(obj);
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

        // PUT api/<BillDetailController>/5
        [HttpPut("{ID}")]
        public async Task<ActionResult> Put(Guid ID, [FromBody] CreateBillDetail obj)
        {
            var billdetail = await _IBillDetailServices.UpdateAsync(ID, obj);
            if (billdetail == 1)
            {
                return Ok("Tao đúng rồi nè :)");
            }
            return Ok(billdetail);
        }

        // DELETE api/<BillDetailController>/5
        [HttpDelete("{ID}")]
        public async Task<ActionResult> Delete(Guid ID)
        {
            var billdetail = await _IBillDetailServices.RemoveAsync(ID);
            return Ok("okok");
        }
    }
}
