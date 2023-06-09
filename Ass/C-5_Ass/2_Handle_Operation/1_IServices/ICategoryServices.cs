using Assignment_Chsarp5_datntph19899._2_Handle_Operation._3_ViewModels;
using Assignment_CS5_Share._1_Models;

namespace Assignment_Chsarp5_datntph19899._2_Handle_Operation._1_IServices
{
    public interface ICategoryServices
    {
        public Task<bool> AddAsync(CategoryViewModels Obj);
        public Task<bool> UpdateAsync(CategoryViewModels Obj);
        public Task<bool> RemoveAsync(Guid ID);
        public Task<Category> GetByIdAsync(Guid ID);
        public Task<List<CategoryViewModels>> GetCategoryAsync();
    }
}
