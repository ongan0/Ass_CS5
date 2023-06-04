using Assignment_CS5_Share._1_Models;
using Assignment_Chsarp5_datntph19899._1_DataProcessing._3_Context;
using Microsoft.EntityFrameworkCore;
using Assignment_Chsarp5_datntph19899._2_Handle_Operation._1_IServices;

namespace Assignment_Chsarp5_datntph19899._2_Handle_Operation._2_Services
{
    public class CouponServices:ICouponServices
    {
        private Assignment_Context _dbContext;
        public CouponServices(Assignment_Context assignment_Context)
        {
            _dbContext = assignment_Context;
        }
        public async Task<bool> AddAsync(Coupons Obj)
        {
            try
            {
                Obj.ID = Guid.NewGuid();
                await _dbContext.AddAsync(Obj);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<Coupons> GetByIdAsync(Guid ID)
        {
            return await _dbContext.Coupons.FindAsync(ID);
        }

        public async Task<List<Coupons>> GetCouponsAsync()
        {
            return await _dbContext.Coupons.ToListAsync();
        }

        public async Task<bool> RemoveAsync(Guid ID)
        {
            try
            {
                var idCp = await _dbContext.Coupons.FirstOrDefaultAsync(c => c.ID == ID);
                if (idCp == null)
                {
                    return false;
                }
                _dbContext.Coupons.Remove(idCp);
                await _dbContext.SaveChangesAsync();
                return true;

            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<bool> UpdateAsync(Coupons Obj)
        {
            try
            {
                var cp = await _dbContext.Coupons.FirstOrDefaultAsync(cp => cp.ID == Obj.ID);
                cp.FoodID = Obj.FoodID;
                cp.ComboID = Obj.ComboID;
                cp.Coupon_Code = Obj.Coupon_Code;
                cp.Discount_Type = Obj.Discount_Type;
                cp.Discount_Amount = Obj.Discount_Amount;
                cp.Minimum_Spend = Obj.Minimum_Spend;
                cp.Maximum_Discount_Amount = Obj.Maximum_Discount_Amount;
                cp.Expiration_Date = Obj.Expiration_Date;
                cp.Create_At = Obj.Create_At;
                cp.Update_At = Obj.Update_At;
                _dbContext.Coupons.Attach(Obj);
                await Task.FromResult<Coupons>(_dbContext.Coupons.Update(Obj).Entity);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
