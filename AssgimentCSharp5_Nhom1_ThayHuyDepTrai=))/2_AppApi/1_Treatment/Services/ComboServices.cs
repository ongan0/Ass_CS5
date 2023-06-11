using _1_AppData._1_DataProcessing.Models;
using _1_AppData._2_Treatment.IReponsitorys;
using _1_AppData._2_Treatment.Reponsitorys;
using _2_AppApi._1_Treatment.IServices;
using _2_AppApi.ViewModels.Combo;

namespace _2_AppApi._1_Treatment.Services
{
    public class ComboServices : IComboServices
    {
        IComboRepon _IComboRepon;
        IFoodRepon _IFoodRepon;
        public ComboServices()
        {
            _IFoodRepon = new FoodRepon();
            _IComboRepon = new ComboRepon();
        }
        public async Task<int> AddAsync(CreateCombo Obj)
        {
            var food = _IFoodRepon.GetByIdAsync(Obj.FoodID);
            var Combo = new Combo()
            {
                ID = Guid.NewGuid(),
                ComboName = Obj.ComboName,
                Description = Obj.Description,
                FoodID = Obj.FoodID
            };
            await _IComboRepon.AddAsync(Combo);
            return 1;
        }

        public Task<Combo> GetByIdAsync(Guid ID)
        {
            var Combo = _IComboRepon.GetByIdAsync(ID);
            return Combo;
        }

        public Task<List<Combo>> GetComboAsync()
        {
            var Combo = _IComboRepon.GetComboAsync();
            return Combo;
        }

        public async Task<int> RemoveAsync(Guid ID)
        {
            await _IComboRepon.RemoveAsync(ID);
            return 1;
        }

        public async Task<int> UpdateAsync(Guid ID, CreateCombo Obj)
        {
            Food food = await _IFoodRepon.GetByIdAsync(Obj.FoodID);
            if(food == null)
            {
                return 2;
            }
            Combo combo = await _IComboRepon.GetByIdAsync(ID);
            combo.ID = ID;
            combo.ComboName = Obj.ComboName;
            combo.Price = Obj.Price;
            combo.Description = Obj.Description;
            combo.FoodID = Obj.FoodID;
            if(await _IComboRepon.UpdateAsync(combo))
            {
                return 1;
            }
            return -1;
        }
    }
}
