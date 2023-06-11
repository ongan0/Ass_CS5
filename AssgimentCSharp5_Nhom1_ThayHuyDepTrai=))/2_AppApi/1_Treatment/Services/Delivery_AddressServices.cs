using _1_AppData._1_DataProcessing.Models;
using _1_AppData._2_Treatment.IReponsitorys;
using _1_AppData._2_Treatment.Reponsitorys;
using _2_AppApi._1_Treatment.IServices;
using _2_AppApi.ViewModels.Delivery_Address;

namespace _2_AppApi.Controllers
{
    public class Delivery_AddressServices : IDelivery_AddressServices
    {
        IDelivery_AddressRepon _IDelivery_AddressRepon;
        IUserRepon _IUserRepon;
        public Delivery_AddressServices()
        {
            _IDelivery_AddressRepon = new Delivery_AddressRepon();
            _IUserRepon = new UserRepon();
        }
        public async Task<int> AddAsync(CreateDelivery_Address Obj)
        {
            var user = await _IUserRepon.GetByIdAsync(Obj.UserID);
            var Delivery_Address = new Delivery_Address()
            {
                ID = Guid.NewGuid(),
                Receiver_Address = Obj.Receiver_Address,
                Receiver_Name = Obj.Receiver_Name,
                PhoneNumber = Obj.PhoneNumber,
                CustomerID = Obj.UserID
            };
            await _IDelivery_AddressRepon.AddAsync(Delivery_Address);
            return 1;
        }

        public Task<Delivery_Address> GetByIdAsync(Guid ID)
        {
            var Delivery_Address = _IDelivery_AddressRepon.GetByIdAsync(ID);
            return Delivery_Address;
        }

        public Task<List<Delivery_Address>> GetDelivery_AddressAsync()
        {
            var Delivery_Address = _IDelivery_AddressRepon.GetDelivery_AddressAsync();
            return Delivery_Address;
        }

        public async Task<int> RemoveAsync(Guid ID)
        {
            await _IDelivery_AddressRepon.RemoveAsync(ID);
            return 1;
        }

        public async Task<int> UpdateAsync(Guid ID, CreateDelivery_Address Obj)
        {
            User user = await _IUserRepon.GetByIdAsync(Obj.UserID);
            if (user == null)
            {
                return 2;
            }
            Delivery_Address Delivery_Address = await _IDelivery_AddressRepon.GetByIdAsync(ID);
            Delivery_Address.ID = ID;
            Delivery_Address.PhoneNumber = Obj.PhoneNumber;
            Delivery_Address.Receiver_Address = Obj.Receiver_Address;
            Delivery_Address.Receiver_Name = Obj.Receiver_Name;
            if(await _IDelivery_AddressRepon.UpdateAsync(Delivery_Address))
            {
                return 1;
            }
            return -1;
        }
    }
}
