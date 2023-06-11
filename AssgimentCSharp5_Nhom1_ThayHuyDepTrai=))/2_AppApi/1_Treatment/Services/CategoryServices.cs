using _1_AppData._1_DataProcessing.Models;
using _1_AppData._2_Treatment.IReponsitorys;
using _1_AppData._2_Treatment.Reponsitorys;
using _2_AppApi._1_Treatment.IServices;
using _2_AppApi.ViewModels.Category;

namespace _2_AppApi._1_Treatment.Services
{
    public class CategoryServices : ICategoryServices
    {
        ICategoryRepon _ICategoryRepon;
        IFoodRepon _IFoodRepon;
        public CategoryServices()
        {
            _ICategoryRepon = new CategoryRepon();
            _IFoodRepon = new FoodRepon();
        }

        public async Task<int> AddAsync(CreateCategory Obj)
        {
            var food = _IFoodRepon.GetByIdAsync(Obj.FoodID);
            var Category = new Category()
            {
                ID = Guid.NewGuid(),
                Name = Obj.Name,
                Description = Obj.Description,
                FoodID = Obj.FoodID
            };
            await _ICategoryRepon.AddAsync(Category);
            return 1;
        }

        public Task<Category> GetByIdAsync(Guid ID)
        {
            var Category = _ICategoryRepon.GetByIdAsync(ID);
            return Category;
        }

        public Task<List<Category>> GetCategoryAsync()
        {
            var Category = _ICategoryRepon.GetCategoryAsync();
            return Category;
        }

        public async Task<int> RemoveAsync(Guid ID)
        {
            await _ICategoryRepon.RemoveAsync(ID);
            return 1;
        }

        public async Task<int> UpdateAsync(Guid ID, CreateCategory Obj)
        {
            Food food = await _IFoodRepon.GetByIdAsync(ID);
            if (food == null)
            {
                return 2;
            }
            Category category = await _ICategoryRepon.GetByIdAsync(ID);
            category.ID = ID;
            category.FoodID = Obj.FoodID;
            category.Name = Obj.Name;
            category.Description = Obj.Description;
            if (await _ICategoryRepon.UpdateAsync(category))
            {
                return 1;
            }
            return -1;
        }
    }
}
