using Assignment_Chsarp5_datntph19899._2_Handle_Operation._1_IServices;
using Assignment_CS5_Share._1_Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Assignment_Chsarp5_datntph19899.Controllers
{
    [Route("api/bill")]
    [ApiController]
    public class BillController : ControllerBase
    {
        private readonly IBillServices _billService;

        public BillController(IBillServices billService)
        {
            _billService = billService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Bill>>> GetBills()
        {
            try
            {
                var bills = await _billService.GetBills();
                return Ok(bills);
            }
            catch (Exception ex)
            {
                // Log or handle the exception
                return StatusCode(500, "An error occurred while retrieving bills.");
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Bill>> GetBillById(Guid id)
        {
            try
            {
                var bill = await _billService.GetBillById(id);
                if (bill == null)
                    return NotFound();

                return Ok(bill);
            }
            catch (Exception ex)
            {
                // Log or handle the exception
                return StatusCode(500, "An error occurred while retrieving the bill.");
            }
        }

        [HttpPost]
        public async Task<ActionResult<Bill>> CreateBill(Bill bill)
        {
            try
            {
                var createdBill = await _billService.CreateBill(bill);
                return Ok(createdBill);
            }
            catch (Exception ex)
            {
                // Log or handle the exception
                return StatusCode(500, "An error occurred while creating the bill.");
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Bill>> UpdateBill(Guid id, Bill bill)
        {
            try
            {
                var updatedBill = await _billService.UpdateBill(id, bill);
                if (updatedBill == null)
                    return NotFound();

                return Ok(updatedBill);
            }
            catch (Exception ex)
            {
                // Log or handle the exception
                return StatusCode(500, "An error occurred while updating the bill.");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBill(Guid id)
        {
            try
            {
                var result = await _billService.DeleteBill(id);
                if (!result)
                    return NotFound();

                return NoContent();
            }
            catch (Exception ex)
            {
                // Log or handle the exception
                return StatusCode(500, "An error occurred while deleting the bill.");
            }
        }
    
}
}
