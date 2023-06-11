using _1_AppData._1_DataProcessing.Models;
using _1_AppData._2_Treatment.IReponsitorys;
using _1_AppData._2_Treatment.Reponsitorys;
using _2_AppApi._1_Treatment.IServices;
using _2_AppApi.ViewModels.Ordel;

namespace _2_AppApi._1_Treatment.Services
{
    public class OrderServices : IOrdelServices
    {
        IOrdelRepon _IOrderRepon { get; set; }
        IUserRepon _IUserRepon { get; set; }
        public OrderServices()
        {
            _IOrderRepon = new OrdelRepon();
            _IUserRepon = new UserRepon();
        }
        public async Task<int> AddAsync(CreateOrdel Obj)
        {
            var usercheck = await _IUserRepon.GetByIdAsync(Obj.UserID);
            if (usercheck == null) { return 2; }
            var ordel = new Ordel()
            {
                OrderID = Guid.NewGuid(),
                OrderDate = Obj.OrderDate,
                TotalPrice = Obj.TotalPrice,
                UserID = Obj.UserID
            };
            if (await _IOrderRepon.AddAsync(ordel))
            {
                return 1;
            }
            return 0;
        }

        public async Task<Ordel> GetByIdAsync(Guid ID)
        {
            var data = await _IOrderRepon.GetByIdAsync(ID);
            return data;
        }

        public Task<List<Ordel>> GetOrdelAsync()
        {
            var data = _IOrderRepon.GetOrdelAsync();
            return data;
        }

        public async Task<int> RemoveAsync(Guid ID)
        {

            if (await _IOrderRepon.RemoveAsync(ID))
            {
                return 1;
            }
            return 0;
        }

        public async Task<int> UpdateAsync(Guid ID, CreateOrdel Obj)
        {
            User user = await _IUserRepon.GetByIdAsync(Obj.UserID);
            if(user == null) { return 2; }
            Ordel Order = await _IOrderRepon.GetByIdAsync(ID);
            Order.OrderID = ID;
            Order.UserID = Obj.UserID;
            Order.TotalPrice = Obj.TotalPrice;
            Order.Status = Obj.Status;
            if (await _IOrderRepon.UpdateAsync(Order))
            {
                return 1;
            }
            return 0;
        }
    }
}
