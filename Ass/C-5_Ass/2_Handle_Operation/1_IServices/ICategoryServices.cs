using Assignment_CS5_Share._1_Models;

namespace Assignment_Chsarp5_datntph19899._2_Handle_Operation._1_IServices
{
    public interface ICategoryServices
    {
        public Task<bool> AddAsync(Category Obj);
        public Task<bool> UpdateAsync(Category Obj);
        public Task<bool> RemoveAsync(Guid ID);
        public Task<Category> GetByIdAsync(Guid ID);
        public Task<List<Category>> GetCategoryAsync();
    }
}
