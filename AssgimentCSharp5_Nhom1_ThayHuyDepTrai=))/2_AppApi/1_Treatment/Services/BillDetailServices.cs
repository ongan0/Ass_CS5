using _1_AppData._1_DataProcessing.Context;
using _1_AppData._1_DataProcessing.Models;
using _1_AppData._2_Treatment.IReponsitorys;
using _1_AppData._2_Treatment.Reponsitorys;
using _2_AppApi._1_Treatment.IServices;
using _2_AppApi.ViewModels.BillDetail;
using Microsoft.EntityFrameworkCore;

namespace _2_AppApi._1_Treatment.Services
{
    public class BillDetailServices : IBillDetailServices
    {
        IBillDetailRepon _IBillDetailRepon;
        IBillRepon _IBillRepon;
        IFoodRepon _IFoodRepon;
        DBContext_Assgiment _context;
        public BillDetailServices(DBContext_Assgiment context)
        {
            _context = context;
            _IBillDetailRepon = new BillDetailRepon();
            _IBillRepon = new BillRepon();
            _IFoodRepon = new FoodRepon();
        }
        public async Task<int> AddAsync(CreateBillDetail Obj)
        {
            var bill = await _IBillRepon.GetByIdAsync(Obj.BillID);
            if(bill == null)
            {
                return 2;
            }
            var food = _IFoodRepon.GetByIdAsync(Obj.FoodID);
            if(food == null)
            {
                return 3;
            }
            var billdetail = new BillDetail()
            {
                ID = Guid.NewGuid(),
                BillID = Obj.BillID,
                FoodID = Obj.FoodID,
                Price = Obj.Price,
                Quantity = Obj.Quantity
            };
            if(await _IBillDetailRepon.AddAsync(billdetail))
            {
                return 1;
            }
            return -1;
        }

        public Task<List<BillDetail>> GetBillDetailAsync()
        {
            var data = _IBillDetailRepon.GetBillDetailAsync();
            return data;
        }

        public async Task<BillDetail> GetByIdAsync(Guid ID)
        {
            var data = await _IBillDetailRepon.GetByIdAsync(ID);
            return data;
        }

        public async Task<List<vmBillDetail>> GetListByIdAsync(Guid ID)
        {
            var billDetails = await _context.BillDetails.Where(c=>c.BillID == ID).ToListAsync();
            var allFoods = await _context.Foods.ToListAsync();
            List<vmBillDetail> foods = (from food in allFoods
                            join billDetail in billDetails on food.ID equals billDetail.FoodID
                            select new vmBillDetail
                            {
                                
                            }
                         ).ToList();
            return foods;
        }

        public async Task<int> RemoveAsync(Guid ID)
        {
            if (await _IBillDetailRepon.RemoveAsync(ID))
            {
                return 1;
            }
            return 0;
        }

        public async Task<int> UpdateAsync(Guid ID, CreateBillDetail Obj)
        {
            var bill = await _IBillRepon.GetByIdAsync(Obj.BillID);
            if (bill == null)
            {
                return 2;
            }
            var food = await _IFoodRepon.GetByIdAsync(Obj.FoodID);
            if (food == null)
            {
                return 2;
            }
            BillDetail BillDetail = await _IBillDetailRepon.GetByIdAsync(ID);
            BillDetail.ID = ID;
            BillDetail.BillID = Obj.BillID;
            BillDetail.FoodID = Obj.FoodID;
            BillDetail.Price = Obj.Price;
            BillDetail.Quantity = Obj.Quantity;
            if (await _IBillDetailRepon.UpdateAsync(BillDetail))
            {
                return 1;
            }
            return 0;
        }
    }
}
