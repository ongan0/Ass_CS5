using _1_AppData._1_DataProcessing.Models;
using _2_AppApi.ViewModels.Delivery_Address;
using _2_AppApi.ViewModels.Food;

namespace _2_AppApi._1_Treatment.IServices
{
    public interface IDelivery_AddressServices
    {
        public Task<int> AddAsync(CreateDelivery_Address Obj);
        public Task<int> UpdateAsync(Guid ID, CreateDelivery_Address Obj);
        public Task<int> RemoveAsync(Guid ID);
        public Task<Delivery_Address> GetByIdAsync(Guid ID);
        public Task<List<Delivery_Address>> GetDelivery_AddressAsync();
    }
}
