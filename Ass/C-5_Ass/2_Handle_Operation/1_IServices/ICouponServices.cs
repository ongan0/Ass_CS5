using Assignment_CS5_Share._1_Models;

namespace Assignment_Chsarp5_datntph19899._2_Handle_Operation._1_IServices
{
    public interface ICouponServices
    {
        public Task<bool> AddAsync(Coupons Obj);
        public Task<bool> UpdateAsync(Coupons Obj);
        public Task<bool> RemoveAsync(Guid ID);
        public Task<Coupons> GetByIdAsync(Guid ID);
        public Task<List<Coupons>> GetCouponsAsync();
    }
}
