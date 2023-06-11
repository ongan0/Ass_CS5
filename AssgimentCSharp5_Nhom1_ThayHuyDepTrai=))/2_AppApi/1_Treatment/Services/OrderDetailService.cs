using _1_AppData._1_DataProcessing.Models;
using _1_AppData._2_Treatment.IReponsitorys;
using _1_AppData._2_Treatment.Reponsitorys;
using _2_AppApi._1_Treatment.IServices;
using _2_AppApi.ViewModels.OrderDetail;

namespace _2_AppApi._1_Treatment.Services
{
    public class OrderDetailService : IOrderDetailServices
    {
        IOrderDetailRepon _IOrderDetailRepon;
        IOrdelRepon _IOrdelRepon;
        IFoodRepon _IFoodRepon;
        public OrderDetailService()
        {
            _IOrderDetailRepon = new OrderDetailRepon();
            _IOrdelRepon = new OrdelRepon();
            _IFoodRepon = new FoodRepon();
        }
        public async Task<int> AddAsync(CreateOrderDetail Obj)
        {
            var ordelcheck = _IOrdelRepon.GetByIdAsync(Obj.OrderID);
            
            if(ordelcheck == null )
            {
                return 2;
            }
            var foodcheck = _IFoodRepon.GetByIdAsync(Obj.FoodID);
            if (foodcheck == null)
            {
                return 3;
            }
            var orderDetail = new OrderDetail()
            {
                ID = Guid.NewGuid(),
                FoodID = Obj.FoodID,
                OrderID = Obj.OrderID,
                Quantity = Obj.Quantity,
            };
            if (await _IOrderDetailRepon.AddAsync(orderDetail))
            {
                return 1;
            }
            return -1;
        }

        public async Task<OrderDetail> GetByIdAsync(Guid ID)
        {
            var data = await _IOrderDetailRepon.GetByIdAsync(ID);
            return data;
        }

        public Task<List<OrderDetail>> GetOrderDetailAsync()
        {
            var data = _IOrderDetailRepon.GetOrderDetailAsync();
            return data;
        }

        public async Task<int> RemoveAsync(Guid ID)
        {
            if (await _IOrderDetailRepon.RemoveAsync(ID))
            {
                return 1;
            }
            return 0;
        }

        public async Task<int> UpdateAsync(Guid ID, CreateOrderDetail Obj)
        {
            var order = await _IOrderDetailRepon.GetByIdAsync(Obj.OrderID);
            if(order == null)
            {
                return 2;
            }
            var food = await _IFoodRepon.GetByIdAsync(Obj.FoodID);
            if(food == null)
            {
                return 2;
            }
            OrderDetail OrderDetail = await _IOrderDetailRepon.GetByIdAsync(ID);
            OrderDetail.ID = ID;
            OrderDetail.OrderID = Obj.OrderID;
            OrderDetail.FoodID = Obj.FoodID;
            OrderDetail.Quantity = Obj.Quantity;
            if (await _IOrderDetailRepon.UpdateAsync(OrderDetail))
            {
                return 1;
            }
            return 0;
        }
    }
}
