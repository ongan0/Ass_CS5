using Assignment_Chsarp5_datntph19899._2_Handle_Operation._1_IServices;
using Assignment_Chsarp5_datntph19899._2_Handle_Operation._3_ViewModels;
using Assignment_CS5_Share._1_Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Assignment_Chsarp5_datntph19899.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ComboController : ControllerBase
    {
        private readonly IComboServices _icomboServices;
        public ComboController(IComboServices comboServices)
        {
            _icomboServices = comboServices;
        }
        [HttpGet]
        public async Task<ActionResult<ComboViewModels>> GetAllCombo()
        {
            var cb = await _icomboServices.GetCombosAsync();
            return Ok(cb);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<ComboViewModels>> GetCombo(Guid id)
        {
            var cb = await _icomboServices.GetComboByIdAsync(id);
            return Ok(cb);
        }
        [HttpPost]
        public async Task<ActionResult<ComboViewModels>> PostCombo(ComboViewModels combo)
        {
            var cb = await _icomboServices.AddComboAsync(combo);
            return Ok();
        }
        [HttpPut]
        public async Task<ActionResult<ComboViewModels>> PutCombo(ComboViewModels combo)
        {
            var cb = await _icomboServices.UpdateComboAsync(combo);
            return Ok();
        }
        [HttpDelete]
        public async Task<ActionResult<ComboViewModels>> DeleteCombo(Guid id)
        {
            var cb = await _icomboServices.GetComboByIdAsync(id);
            if (cb == null)
            {
                return NotFound();
            }
            var cbb = await _icomboServices.DeleteComboAsync(id);
            return Ok();
        }
    }
}
