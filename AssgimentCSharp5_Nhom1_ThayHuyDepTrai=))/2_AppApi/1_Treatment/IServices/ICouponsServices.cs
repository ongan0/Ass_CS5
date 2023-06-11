using _1_AppData._1_DataProcessing.Models;
using _2_AppApi.ViewModels.Combo;
using _2_AppApi.ViewModels.Coupons;

namespace _2_AppApi._1_Treatment.IServices
{
    public interface ICouponsServices
    {
        public Task<int> AddAsync(CreateCoupons Obj);
        public Task<int> UpdateAsync(Guid ID, CreateCoupons Obj);
        public Task<int> RemoveAsync(Guid ID);
        public Task<Coupons> GetByIdAsync(Guid ID);
        public Task<List<Coupons>> GetCouponsAsync();
    }
}
