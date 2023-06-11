using _1_AppData._1_DataProcessing.Models;
using _2_AppApi.ViewModels.BillDetail;

namespace _2_AppApi._1_Treatment.IServices
{
    public interface IBillDetailServices
    {
        public Task<int> AddAsync(CreateBillDetail Obj);
        public Task<int> UpdateAsync(Guid ID, CreateBillDetail Obj);
        public Task<int> RemoveAsync(Guid ID);
        public Task<BillDetail> GetByIdAsync(Guid ID);
        public Task<List<BillDetail>> GetBillDetailAsync();
    }
}
