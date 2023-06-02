using Assignment_CS5_Share._1_Models;
using Assignment_Chsarp5_datntph19899._2_Handle_Operation._1_IServices;
using Assignment_Chsarp5_datntph19899._2_Handle_Operation._3_ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Assignment_Chsarp5_datntph19899.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        
        public static List<Role> Roles = new List<Role>();
        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(Roles);
        }
        [HttpPost]
        public IActionResult Create(Role_ViewModels role_ViewModels)
        {
            var Role = new Role()
            {
                ID = role_ViewModels.ID,
                Name = role_ViewModels.Name,
                Description = role_ViewModels.Description,
                Status = role_ViewModels.Status
            };
            Roles.Add(Role);
            return Ok(new
            {
                Success = true,
                Data = Role
            });
        }
    }
}
