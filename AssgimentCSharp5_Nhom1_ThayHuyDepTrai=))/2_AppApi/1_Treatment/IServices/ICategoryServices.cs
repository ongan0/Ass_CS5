using _1_AppData._1_DataProcessing.Models;
using _2_AppApi.ViewModels.Bill;
using _2_AppApi.ViewModels.Category;

namespace _2_AppApi._1_Treatment.IServices
{
    public interface ICategoryServices
    {
        public Task<int> AddAsync(CreateCategory Obj);
        public Task<int> UpdateAsync(Guid ID, CreateCategory Obj);
        public Task<int> RemoveAsync(Guid ID);
        public Task<Category> GetByIdAsync(Guid ID);
        public Task<List<Category>> GetCategoryAsync();
    }
}
