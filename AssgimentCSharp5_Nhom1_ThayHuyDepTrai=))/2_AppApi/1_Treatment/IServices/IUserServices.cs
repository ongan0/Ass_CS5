using _1_AppData._1_DataProcessing.Models;
using _2_AppApi.ViewModels.Role;
using _2_AppApi.ViewModels.User;

namespace _2_AppApi._1_Treatment.IServices
{
    public interface IUserServices
    {
        public Task<int> AddAsync(CreateUser Obj);
        public Task<int> UpdateAsync(Guid ID, CreateUser Obj);
        public Task<int> RemoveAsync(Guid ID);
        public Task<User> GetByIdAsync(Guid ID);
        public Task<List<User>> GetUserAsync();
    }
}
