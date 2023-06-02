using Assignment_CS5_Share._1_Models;

namespace Assignment_Chsarp5_datntph19899._2_Handle_Operation._1_IServices
{
    public interface IExpress_DeliveryServices
    {
        Task<List<Express_Delivery>> GetExpressDeliveriesAsync();
        Task<Express_Delivery> GetExpressDeliveryByIdAsync(Guid id);
        Task<Guid> AddExpressDeliveryAsync(Express_Delivery expressDelivery);
        Task<bool> UpdateExpressDeliveryAsync(Express_Delivery expressDelivery);
        Task<bool> DeleteExpressDeliveryAsync(Guid id);
    }
}
