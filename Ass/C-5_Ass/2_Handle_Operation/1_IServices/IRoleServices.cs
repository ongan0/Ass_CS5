using Assignment_CS5_Share._1_Models;

namespace Assignment_Chsarp5_datntph19899._2_Handle_Operation._1_IServices
{
    public interface IRoleServices
    {
        public Task<bool> AddAsync(Role Obj);
        public Task<bool> UpdateAsync(Guid ID, Role Obj);
        public Task<bool> RemoveAsync(Guid ID);
        public Task<Role> GetByIdAsync(Guid ID);
        public Task<List<Role>> GetRoleAsync();
    }
}
