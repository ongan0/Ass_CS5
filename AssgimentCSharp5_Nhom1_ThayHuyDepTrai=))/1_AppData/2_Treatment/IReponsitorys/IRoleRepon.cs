using _1_AppData._1_DataProcessing.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1_AppData._2_Treatment.IReponsitorys
{
    public interface IRoleRepon
    {
        public Task<bool> AddAsync(Role Obj);
        public Task<bool> UpdateAsync(Role Obj);
        public Task<bool> RemoveAsync(Guid ID);
        public Task<Role> GetByIdAsync(Guid ID);
        public Task<List<Role>> GetRoleAsync();
    }
}
