using Assignment_Chsarp5_datntph19899._1_DataProcessing._3_Context;
using Assignment_Chsarp5_datntph19899._2_Handle_Operation._1_IServices;
using Assignment_CS5_Share._1_Models;
using Microsoft.EntityFrameworkCore;

namespace Assignment_Chsarp5_datntph19899._2_Handle_Operation._2_Services
{
    public class BillServices : IBillServices
    {
        private readonly Assignment_Context _context;

        public BillServices(Assignment_Context context)
        {
            _context = context;
        }

        public async Task<List<Bill>> GetBills()
        {
            return await _context.Bills.ToListAsync();
        }

        public async Task<Bill> GetBillById(Guid id)
        {
            return await _context.Bills.FindAsync(id);
        }

        public async Task<Bill> CreateBill(Bill bill)
        {
            bill.ID = Guid.NewGuid();
            _context.Bills.Add(bill);
            await _context.SaveChangesAsync();
            return bill;
        }

        public async Task<Bill> UpdateBill(Guid id, Bill bill)
        {
            var existingBill = await _context.Bills.FindAsync(id);
            if (existingBill == null)
                return null;

            existingBill.UserID = bill.UserID;
            existingBill.Delivery_AddressID = bill.Delivery_AddressID;
            existingBill.Shipping_Address = bill.Shipping_Address;
            existingBill.OrderDate = bill.OrderDate;
            existingBill.TotalPrice = bill.TotalPrice;
            existingBill.Delivery_Date = bill.Delivery_Date;
            existingBill.Actual_Delivery_Date = bill.Actual_Delivery_Date;
            existingBill.Delivery_Status = bill.Delivery_Status;
            existingBill.Shipping_Cost = bill.Shipping_Cost;
            existingBill.Payment_Status = bill.Payment_Status;

            await _context.SaveChangesAsync();

            return existingBill;
        }

        public async Task<bool> DeleteBill(Guid id)
        {
            var bill = await _context.Bills.FindAsync(id);
            if (bill == null)
                return false;

            _context.Bills.Remove(bill);
            await _context.SaveChangesAsync();

            return true;
        }
    }
}
