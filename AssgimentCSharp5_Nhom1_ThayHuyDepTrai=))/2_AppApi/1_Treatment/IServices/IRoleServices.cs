using _1_AppData._1_DataProcessing.Models;
using _2_AppApi.ViewModels.Role;

namespace _2_AppApi._1_Treatment.IServices
{
    public interface IRoleServices
    {
        public Task<int> AddAsync(CreateRole Obj);
        public Task<int> UpdateAsync(Guid ID, CreateRole Obj);
        public Task<int> RemoveAsync(Guid ID);
        public Task<Role> GetByIdAsync(Guid ID);
        public Task<List<Role>> GetRoleAsync();
    }
}
