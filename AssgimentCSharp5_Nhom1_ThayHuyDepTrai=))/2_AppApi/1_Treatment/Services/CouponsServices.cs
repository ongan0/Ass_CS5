using _1_AppData._1_DataProcessing.Models;
using _1_AppData._2_Treatment.IReponsitorys;
using _1_AppData._2_Treatment.Reponsitorys;
using _2_AppApi._1_Treatment.IServices;
using _2_AppApi.ViewModels.Coupons;

namespace _2_AppApi._1_Treatment.Services
{
    public class CouponsServices : ICouponsServices
    {
        ICouponsRepon _ICouponsRepon;
        IFoodRepon _IFoodRepon;
        IComboRepon _IComboRepon;
        public CouponsServices()
        {
            _ICouponsRepon = new CouponsRepon();
            _IFoodRepon = new FoodRepon();
            _IComboRepon = new ComboRepon();
        }
        public async Task<int> AddAsync(CreateCoupons Obj)
        {
            var combo = await _IComboRepon.GetByIdAsync(Obj.ComboID);
            if (combo == null)
            {
                return 2;
            }
            var food = await _IFoodRepon.GetByIdAsync(Obj.FoodID);
            if (food == null)
            {
                return 3;
            }
            var Coupons = new Coupons()
            {
                ID = Guid.NewGuid(),
                ComboID = Obj.ComboID,
                FoodID = Obj.FoodID,
                Coupon_Code = Obj.Coupon_Code,
                Discount_Amount = Obj.Discount_Amount,
                Discount_Type = Obj.Discount_Type,
                Minimum_Spend = Obj.Minimum_Spend,
                Maximum_Discount_Amount = Obj.Maximum_Discount_Amount,
                Expiration_Date = Obj.Expiration_Date,
                Create_At = Obj.Create_At,
                Update_At = Obj.Update_At
            };
            if (await _ICouponsRepon.AddAsync(Coupons))
            {
                return 1;
            }
            return -1;
        }

        public async Task<Coupons> GetByIdAsync(Guid ID)
        {
            var data = await _ICouponsRepon.GetByIdAsync(ID);
            return data;
        }

        public async Task<List<Coupons>> GetCouponsAsync()
        {
            var data = await _ICouponsRepon.GetCouponsAsync();
            return data;
        }

        public async Task<int> RemoveAsync(Guid ID)
        {
            Coupons Coupons = await _ICouponsRepon.GetByIdAsync(ID);
            if (Coupons == null)
            {
                return 2;
            }
            if (await _ICouponsRepon.RemoveAsync(ID))
            {
                return 1;
            }
            return -1;
        }

        public async Task<int> UpdateAsync(Guid ID, CreateCoupons Obj)
        {

            var combo = await _IComboRepon.GetByIdAsync(Obj.ComboID);
            if (combo == null)
            {
                return 2;
            }
            var food = await _IFoodRepon.GetByIdAsync(Obj.FoodID);
            if (food == null)
            {
                return 3;
            }
            var Coupons = await _ICouponsRepon.GetByIdAsync(ID);
            Coupons.ComboID = Obj.ComboID;
            Coupons.FoodID = Obj.FoodID;
            Coupons.Coupon_Code = Obj.Coupon_Code;
            Coupons.Discount_Amount = Obj.Discount_Amount;
            Coupons.Discount_Type = Obj.Discount_Type;
            Coupons.Minimum_Spend = Obj.Minimum_Spend;
            Coupons.Maximum_Discount_Amount = Obj.Maximum_Discount_Amount;
            Coupons.Expiration_Date = Obj.Expiration_Date;
            Coupons.Create_At = Obj.Create_At;
            Coupons.Update_At = Obj.Update_At;
            if(await _ICouponsRepon.UpdateAsync(Coupons))
            {
                return 1;
            }
            return -1;
        }
    }
}
