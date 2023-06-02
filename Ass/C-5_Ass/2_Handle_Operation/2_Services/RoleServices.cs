using Assignment_CS5_Share._1_Models;
using Assignment_Chsarp5_datntph19899._1_DataProcessing._3_Context;
using Assignment_Chsarp5_datntph19899._2_Handle_Operation._1_IServices;
using Microsoft.EntityFrameworkCore;

namespace Assignment_Chsarp5_datntph19899._2_Handle_Operation._2_Services
{
    public class RoleServices : IRoleServices
    {
        Assignment_Context _dbContext;
        public RoleServices()
        {
            this._dbContext = new Assignment_Context();
        }

        public async Task<bool> AddAsync(Role Obj)
        {
            try
            {
                await _dbContext.Roles.AddAsync(Obj);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public Task<Role> GetByIdAsync(Guid ID)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Role>> GetRoleAsync()
        {
            var list = await _dbContext.Roles.ToListAsync();
            if (list == null)
            {
                return new();
            }
            return list;
        }

        public async Task<bool> RemoveAsync(Guid ID)
        {
            try
            {
                var listObj = await _dbContext.Roles.ToListAsync();
                var obj = listObj.FirstOrDefault(c => c.ID == ID);
                obj.Status = 1;

                _dbContext.Roles.Attach(obj);
                await Task.FromResult<Role>(_dbContext.Roles.Update(obj).Entity);
                await _dbContext.SaveChangesAsync();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<bool> UpdateAsync(Guid ID, Role Obj)
        {
            try
            {
                var listObj = await _dbContext.Roles.ToListAsync();
                var objForUpdate = listObj.FirstOrDefault(c => c.ID == ID);

                objForUpdate.Name = Obj.Name;
                objForUpdate.Status = Obj.Status;

                _dbContext.Roles.Attach(Obj);
                await Task.FromResult<Role>(_dbContext.Roles.Update(Obj).Entity);
                await _dbContext.SaveChangesAsync();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
