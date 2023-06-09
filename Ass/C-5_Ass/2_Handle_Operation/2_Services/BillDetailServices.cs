using Assignment_Chsarp5_datntph19899._1_DataProcessing._3_Context;
using Assignment_Chsarp5_datntph19899._2_Handle_Operation._1_IServices;
using Assignment_CS5_Share._1_Models;
using Microsoft.EntityFrameworkCore;

namespace Assignment_Chsarp5_datntph19899._2_Handle_Operation._2_Services
{
    public class BillDetailServices : IBillDetailServices
    {
        private readonly Assignment_Context _context;

        public BillDetailServices(Assignment_Context context)
        {
            _context = context;
        }

        public async Task<List<BillDetail>> GetBillDetails()
        {
            return await _context.BillDetails.ToListAsync();
        }

        public async Task<BillDetail> GetBillDetailById(Guid id)
        {
            return await _context.BillDetails.FindAsync(id);
        }

        public async Task<BillDetail> CreateBillDetail(BillDetail billDetail)
        {
            _context.BillDetails.Add(billDetail);
            await _context.SaveChangesAsync();
            return billDetail;
        }

        public async Task<BillDetail> UpdateBillDetail(Guid id, BillDetail billDetail)
        {
            var existingBillDetail = await _context.BillDetails.FindAsync(id);
            if (existingBillDetail == null)
                return null;

            existingBillDetail.BillID = billDetail.BillID;
            existingBillDetail.FoodID = billDetail.FoodID;
            existingBillDetail.Price = billDetail.Price;
            existingBillDetail.Quantity = billDetail.Quantity;

            await _context.SaveChangesAsync();
            return existingBillDetail;
        }

        public async Task<bool> DeleteBillDetail(Guid id)
        {
            var billDetail = await _context.BillDetails.FindAsync(id);
            if (billDetail == null)
                return false;

            _context.BillDetails.Remove(billDetail);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
