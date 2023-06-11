using _1_AppData._1_DataProcessing.Models;
using _1_AppData._2_Treatment.IReponsitorys;
using _1_AppData._2_Treatment.Reponsitorys;
using _2_AppApi._1_Treatment.IServices;
using _2_AppApi.ViewModels.Food;

namespace _2_AppApi._1_Treatment.Services
{
    public class FoodServices : IFoodServices
    {
        private readonly IFoodRepon _foodRepon;
        public FoodServices()
        {
            _foodRepon = new FoodRepon();
        }
        public async Task<int> AddAsync(CreateFood Obj)
        {
            Food food = new Food()
            {
                ID = Guid.NewGuid(),
                FoodName = Obj.FoodName,
                Price = Obj.Price,
                Images = Obj.Images,
                Description = Obj.Description,

            };
            if (await _foodRepon.AddAsync(food))
            {
                return 1;
            }
            return -1;

        }

        public async Task<Food> GetByIdAsync(Guid ID)
        {
            var data = await _foodRepon.GetByIdAsync(ID);
            if (data == null)
            {
                return null;
            }
            return data;
        }

        public async Task<List<Food>> GetRoleAsync()
        {
            var data = await _foodRepon.GetFoodAsync();
            if (data == null)
            {
                return null;
            }
            return data;
        }

        public async Task<int> RemoveAsync(Guid ID)
        {
            Food food = await _foodRepon.GetByIdAsync(ID);
            if (food == null)
            {
                return 2;
            }
            if (await _foodRepon.RemoveAsync(food))
            {
                return 1;
            }
            return -1;
        }

        public async Task<int> UpdateAsync(Guid ID, CreateFood Obj)
        {
            Food food = await _foodRepon.GetByIdAsync(ID);
            if (food == null)
            {
                return 2;
            }
            food.FoodName = Obj.FoodName;
            food.Price = Obj.Price;
            food.Images = Obj.Images;
            food.Description = Obj.Description;


            if (await _foodRepon.UpdateAsync(food))
            {
                return 1;
            }
            return -1;
        }
    }
}
