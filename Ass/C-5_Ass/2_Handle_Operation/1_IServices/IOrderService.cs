using Assignment_CS5_Share._1_Models;

namespace Assignment_Chsarp5_datntph19899._2_Handle_Operation._1_IServices
{
    public interface IOrderService
    {
        public Task<bool> CreateNewOrder(Order order);
        public Task<bool> UpdateOrder(Order order);
        public Task<bool> DeleteOrder(Guid id);
        public Task<Order> GetOrderByUserId(Guid id);
        public Task<List<Order>> GetAllOrder();
    }
}
