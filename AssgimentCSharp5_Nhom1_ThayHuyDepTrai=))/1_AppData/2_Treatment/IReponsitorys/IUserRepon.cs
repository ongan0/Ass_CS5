using _1_AppData._1_DataProcessing.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1_AppData._2_Treatment.IReponsitorys
{
    public interface IUserRepon
    {
        public Task<bool> AddAsync(User Obj);
        public Task<bool> UpdateAsync(User Obj);
        public Task<bool> RemoveAsync(Guid ID);
        public Task<User> GetByIdAsync(Guid ID);
        public Task<List<User>> GetUserAsync();
    }
}
