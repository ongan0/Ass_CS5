using _1_AppData._1_DataProcessing.Models;
using _2_AppApi.ViewModels.Food;
using _2_AppApi.ViewModels.User;

namespace _2_AppApi._1_Treatment.IServices
{
    public interface IFoodServices
    {
        public Task<int> AddAsync(CreateFood Obj);
        public Task<int> UpdateAsync(Guid ID, CreateFood Obj);
        public Task<int> RemoveAsync(Guid ID);
        public Task<Food> GetByIdAsync(Guid ID);
        public Task<List<Food>> GetRoleAsync();
    }
}
