using _1_AppData._1_DataProcessing.Models;
using _2_AppApi.ViewModels.Category;
using _2_AppApi.ViewModels.Combo;

namespace _2_AppApi._1_Treatment.IServices
{
    public interface IComboServices
    {
        public Task<int> AddAsync(CreateCombo Obj);
        public Task<int> UpdateAsync(Guid ID, CreateCombo Obj);
        public Task<int> RemoveAsync(Guid ID);
        public Task<Combo> GetByIdAsync(Guid ID);
        public Task<List<Combo>> GetComboAsync();
    }
}
