using _1_AppData._1_DataProcessing.Models;
using _1_AppData._2_Treatment.IReponsitorys;
using _1_AppData._2_Treatment.Reponsitorys;
using _2_AppApi._1_Treatment.IServices;
using _2_AppApi.ViewModels.Bill;

namespace _2_AppApi._1_Treatment.Services
{
    public class BillServices : IBillServices
    {
        IBillRepon _IBillRepon;
        IUserRepon _IUserRepon;
        IDelivery_AddressRepon _IDelivery_AddressRepon;
        public BillServices()
        {
            _IBillRepon = new BillRepon();
            _IUserRepon = new UserRepon();
            _IDelivery_AddressRepon = new Delivery_AddressRepon();
        }
        public async Task<int> AddAsync(CreateBill Obj)
        {
            User user = await _IUserRepon.GetByIdAsync(Obj.UserID);
            if (user == null)
            {
                return 3;
            }
            //Delivery_Address delivery_Address = await _IDelivery_AddressRepon.GetByIdAsync(Obj.Delivery_AddressID);
            //if (delivery_Address == null)
            //{
            //    return 4;
            //}
            Bill bill = new Bill()
            {
                ID = Guid.NewGuid(),
                Receiver_Address = Obj.Receiver_Address,
                Receiver_Name = Obj.Receiver_Name,
                PhoneNumber = Obj.PhoneNumber,
                Shipping_Address = Obj.Shipping_Address,
                OrderDate = Obj.OrderDate,
                TotalPrice = Obj.TotalPrice,
                Delivery_Date = Obj.Delivery_Date,
                Actual_Delivery_Date = Obj.Actual_Delivery_Date,
                Delivery_Status = Obj.Delivery_Status,
                Shipping_Cost = Obj.Shipping_Cost,
                Payment_Status = Obj.Payment_Status,
                //Delivery_Address = delivery_Address,

            };
            if (await _IBillRepon.AddAsync(bill))
            {
                return 1;
            }
            return -1;
        }

        public async Task<List<Bill>> GetBillAsync()
        {
            var data = await _IBillRepon.GetBillAsync();
            return data;
        }

        public async Task<Bill> GetByIdAsync(Guid ID)
        {
            var data = await _IBillRepon.GetByIdAsync(ID);
            return data;
        }
        public async Task<int> RemoveAsync(Guid ID)
        {
            Bill bill = await _IBillRepon.GetByIdAsync(ID);
            if (bill == null)
            {
                return 2;
            }
            if (await _IBillRepon.RemoveAsync(bill))
            {
                return 1;
            }
            return -1;
        }

        public async Task<int> UpdateAsync(Guid ID, CreateBill Obj)
        {
            Bill bill = await _IBillRepon.GetByIdAsync(ID);
            if (bill == null)
            {
                return 2;
            }
            User user = await _IUserRepon.GetByIdAsync(Obj.UserID);
            if (user == null)
            {
                return 3;
            }
            //Delivery_Address delivery_Address = await _IDelivery_AddressRepon.GetByIdAsync(Obj.Delivery_AddressID);
            //if (delivery_Address == null)
            //{
            //    return 4;
            //}
            bill.ID = Guid.NewGuid();
            bill.Receiver_Address = Obj.Receiver_Address;
            bill.Receiver_Name = Obj.Receiver_Name;
            bill.PhoneNumber = Obj.PhoneNumber;
            bill.Shipping_Address = Obj.Shipping_Address;
            bill.OrderDate = Obj.OrderDate;
            bill.TotalPrice = Obj.TotalPrice;
            bill.Delivery_Date = Obj.Delivery_Date;
            bill.Actual_Delivery_Date = Obj.Actual_Delivery_Date;
            bill.Delivery_Status = Obj.Delivery_Status;
            bill.Shipping_Cost = Obj.Shipping_Cost;
            bill.Payment_Status = Obj.Payment_Status;
            if (await _IBillRepon.UpdateAsync(bill))
            {
                return 1;
            }
            return -1;

        }
    }
}
