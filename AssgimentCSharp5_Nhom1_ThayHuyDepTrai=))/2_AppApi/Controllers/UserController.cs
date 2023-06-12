using _2_AppApi._1_Treatment.IServices;
using _2_AppApi._1_Treatment.Services;
using _2_AppApi.ViewModels.Role;
using _2_AppApi.ViewModels.User;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace _2_AppApi.Controllers
{
    [Route("api/user")]
    [ApiController]
    public class UserController : ControllerBase
    {
        IUserServices _IUserServices;
        public UserController()
        {
            _IUserServices = new UserServices();
        }
        // GET: api/<UserController>
        [HttpGet("get")]
        public async Task<ActionResult> Get()
        {
            var user = await _IUserServices.GetUserAsync();
            return Ok(user);
        }

        // GET api/<UserController>/5
        [HttpGet("get-{ID}")]
        public async Task<ActionResult> Get(Guid ID)
        {
            try
            {
                var user = await _IUserServices.GetByIdAsync(ID);
                return Ok(user);
            }
            catch (Exception)
            {
                return Ok("Rồi! Mày xong rồi");
            }
            
        }

        // POST api/<UserController>
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] CreateUser obj)
        {
            try
            {
                int a = await _IUserServices.AddAsync(obj);
                if(a == 1) {
                    return Ok("Thêm thành công");
                }
                if (a == 2)
                {
                    return Ok("sai role");
                }
                return Ok("sssssssssssss");
            }
            catch (Exception)
            {
                return Ok("Rồi! Mày xong rồi");
            }
            
        }

        // PUT api/<UserController>/5
        [HttpPut("{ID}")]
        public async Task<ActionResult> Put(Guid ID, [FromBody] CreateUser obj)
        {
            var role = await _IUserServices.UpdateAsync(ID, obj);
            if (role == 1)
            {
                return Ok("Tao đúng rồi nè :)");
            }
            return Ok(role);
        }


        // DELETE api/<UserController>/5
        [HttpDelete("{ID}")]
        public async Task<ActionResult> Delete(Guid ID)
        {
            var user = await _IUserServices.RemoveAsync(ID);
            return Ok("okok");
        }
    }
}
