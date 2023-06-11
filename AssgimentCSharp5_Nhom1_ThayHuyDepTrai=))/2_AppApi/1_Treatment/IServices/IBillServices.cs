using _1_AppData._1_DataProcessing.Models;
using _2_AppApi.ViewModels.Bill;
using _2_AppApi.ViewModels.User;

namespace _2_AppApi._1_Treatment.IServices
{
    public interface IBillServices
    {
        public Task<int> AddAsync(CreateBill Obj);
        public Task<int> UpdateAsync(Guid ID, CreateBill Obj);
        public Task<int> RemoveAsync(Guid ID);
        public Task<Bill> GetByIdAsync(Guid ID);
        public Task<List<Bill>> GetBillAsync();
    }
}
