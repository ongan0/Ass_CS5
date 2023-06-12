using _2_AppApi._1_Treatment.IServices;
using _2_AppApi._1_Treatment.Services;
using _2_AppApi.ViewModels.Category;
using _2_AppApi.ViewModels.Combo;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace _2_AppApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ComboController : ControllerBase
    {
        IFoodServices _IFoodServices;
        IComboServices _IComboServices;
        public ComboController()
        {
            _IComboServices = new ComboServices();
            _IFoodServices = new FoodServices();
        }
        // GET: api/<ComboController>
        [HttpGet]
        public async Task<ActionResult> Get()
        {
            var data = await _IComboServices.GetComboAsync();
            return Ok(data);
        }

        // GET api/<ComboController>/5
        [HttpGet("{ID}")]
        public async Task<ActionResult> Get(Guid ID)
        {
            var Combo = await _IComboServices.GetByIdAsync(ID);
            return Ok(Combo);
        }

        // POST api/<ComboController>
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] CreateCombo obj)
        {
            await _IComboServices.AddAsync(obj);
            return Ok();
        }

        // PUT api/<ComboController>/5
        [HttpPut("{ID}")]
        public async Task<ActionResult> Put(Guid ID, [FromBody] CreateCombo obj)
        {
            var Combo = await _IComboServices.UpdateAsync(ID, obj);
            if (Combo == 1)
            {
                return Ok("Tao đúng rồi nè :)");
            }
            return Ok(Combo);
        }

        // DELETE api/<ComboController>/5
        [HttpDelete("{ID}")]
        public async Task<ActionResult> Delete(Guid ID)
        {
            var Combo = _IComboServices.RemoveAsync(ID);
            return Ok("okok");
        }
    }
}
