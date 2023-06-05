using Assignment_CS5_Share._1_Models;

namespace Assignment_Chsarp5_datntph19899._2_Handle_Operation._1_IServices
{
    public interface IOrderDetailService
    {
        public Task<bool> CreateNewOrderDetails(OrderDetail orderDetail);
        public Task<bool> UpdateOrderDetails(OrderDetail orderDetail);
        public Task<bool> DeleteOrderDetails(Guid id);
        public Task<OrderDetail> GetOrderDetailsByUserId(Guid id);
        public Task<List<OrderDetail>> GetAllOrderDetails();
    }
}
