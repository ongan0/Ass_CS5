using _1_AppData._1_DataProcessing.Models;
using _2_AppApi.ViewModels.Ordel;
using _2_AppApi.ViewModels.OrderDetail;

namespace _2_AppApi._1_Treatment.IServices
{
    public interface IOrderDetailServices
    {
        public Task<int> AddAsync(CreateOrderDetail Obj);
        public Task<int> UpdateAsync(Guid ID, CreateOrderDetail Obj);
        public Task<int> RemoveAsync(Guid ID);
        public Task<OrderDetail> GetByIdAsync(Guid ID);
        public Task<List<OrderDetail>> GetOrderDetailAsync();
    }
}
