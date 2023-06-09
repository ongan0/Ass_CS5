using Assignment_Chsarp5_datntph19899._2_Handle_Operation._1_IServices;
using Assignment_CS5_Share._1_Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Assignment_Chsarp5_datntph19899.Controllers
{
    [Route("api/billdetail")]
    [ApiController]
    public class BillDetailController : ControllerBase
    {
        private readonly IBillDetailServices _billDetailService;

        public BillDetailController(IBillDetailServices billDetailService)
        {
            _billDetailService = billDetailService;
        }

        [HttpGet]
        public async Task<ActionResult<List<BillDetail>>> GetBillDetails()
        {
            try
            {
                var billDetails = await _billDetailService.GetBillDetails();
                return Ok(billDetails);
            }
            catch (Exception ex)
            {
                // Log or handle the exception
                return StatusCode(500, "An error occurred while retrieving bill details.");
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<BillDetail>> GetBillDetailById(Guid id)
        {
            try
            {
                var billDetail = await _billDetailService.GetBillDetailById(id);
                if (billDetail == null)
                    return NotFound();

                return Ok(billDetail);
            }
            catch (Exception ex)
            {
                // Log or handle the exception
                return StatusCode(500, "An error occurred while retrieving the bill detail.");
            }
        }

        [HttpPost]
        public async Task<ActionResult<BillDetail>> CreateBillDetail(BillDetail billDetail)
        {
            try
            {
                var createdBillDetail = await _billDetailService.CreateBillDetail(billDetail);
                return Ok(createdBillDetail);
            }
            catch (Exception ex)
            {
                // Log or handle the exception
                return StatusCode(500, "An error occurred while creating the bill detail.");
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<BillDetail>> UpdateBillDetail(Guid id, BillDetail billDetail)
        {
            try
            {
                var updatedBillDetail = await _billDetailService.UpdateBillDetail(id, billDetail);
                if (updatedBillDetail == null)
                    return NotFound();

                return Ok(updatedBillDetail);
            }
            catch (Exception ex)
            {
                // Log or handle the exception
                return StatusCode(500, "An error occurred while updating the bill detail.");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBillDetail(Guid id)
        {
            try
            {
                var result = await _billDetailService.DeleteBillDetail(id);
                if (!result)
                    return NotFound();

                return NoContent();
            }
            catch (Exception ex)
            {
                // Log or handle the exception
                return StatusCode(500, "An error occurred while deleting the bill detail.");
            }
        }
    }
}
