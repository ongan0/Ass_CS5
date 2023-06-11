using _1_AppData._1_DataProcessing.Models;
using _1_AppData._2_Treatment.IReponsitorys;
using _1_AppData._2_Treatment.Reponsitorys;
using _2_AppApi._1_Treatment.IServices;
using _2_AppApi.ViewModels.Role;
using Microsoft.AspNetCore.Rewrite;

namespace _2_AppApi._1_Treatment.Services
{
    public class RoleServices : IRoleServices
    {
        public readonly IRoleRepon _IRoleRepon;
        public RoleServices(/*RoleRepon roleRepon*/)
        {
            _IRoleRepon = new RoleRepon();
        }
        public async Task<int> AddAsync(CreateRole Obj)
        {
            try
            {
                var role = new Role()
                {
                    ID = Guid.NewGuid(),
                    Name = Obj.Name,
                    Description = Obj.Description,
                    Status = Obj.Status
                };
                await _IRoleRepon.AddAsync(role);
                return 1;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public Task<Role> GetByIdAsync(Guid ID)
        {
            var role = _IRoleRepon.GetByIdAsync(ID);
            return role;
        }

        public Task<List<Role>> GetRoleAsync()
        {
            var role = _IRoleRepon.GetRoleAsync();
            return role;
        }

        public async Task<int> RemoveAsync(Guid ID)
        {
            await _IRoleRepon.RemoveAsync(ID);
            return 1;
        }

        public async Task<int> UpdateAsync(Guid ID, CreateRole Obj)
        {
            var role = new Role()
            {
                ID = ID,
                Name = Obj.Name,
                Description = Obj.Description,
                Status = Obj.Status
            };
            await _IRoleRepon.UpdateAsync(role);
            return 1;
        }
    }
}
