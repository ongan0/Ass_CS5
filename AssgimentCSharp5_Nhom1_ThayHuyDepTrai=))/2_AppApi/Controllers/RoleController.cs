using _1_AppData._1_DataProcessing.Models;
using _1_AppData._2_Treatment.IReponsitorys;
using _2_AppApi._1_Treatment.IServices;
using _2_AppApi._1_Treatment.Services;
using _2_AppApi.ViewModels.Role;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace _2_AppApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        IRoleServices _IRoleServices;
        public RoleController(/*IRoleServices roleServices*/)
        {
            _IRoleServices = new RoleServices();
        }
        // GET: api/<RoleController>
        [HttpGet]
        public async Task<ActionResult> Get()
        {
            var roles = await _IRoleServices.GetRoleAsync();
            return Ok(roles);
        }
        // GET api/<RoleController>/5
        [HttpGet("{ID}")]
        public async Task<ActionResult> Get(Guid ID)
        {
            var role = await _IRoleServices.GetByIdAsync(ID);
            return Ok(role);
        }

        // POST api/<RoleController>
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] CreateRole obj)
        {
            await _IRoleServices.AddAsync(obj);
            return Ok();
        }

        // PUT api/<RoleController>/5
        [HttpPut("{ID}")]
        public async Task<ActionResult> Put(Guid ID, [FromBody] CreateRole obj)
        {
            var role = await _IRoleServices.UpdateAsync(ID, obj);
            if(role == 1)
            {
                return Ok("Tao đúng rồi nè :)");
            }
            return Ok(role);
        }

        // DELETE api/<RoleController>/5
        [HttpDelete("{ID}")]
        public async Task<ActionResult> Delete(Guid ID)
        {
            var role = _IRoleServices.RemoveAsync(ID);
            return Ok("okok");
        }
    }
}
